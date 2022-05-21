using ABEGestionProyectos.Core.Models;
using ABEGestionProyectos.Services.Contracts;
using ABEGestionProyectos.Web.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABEGestionProyectos.Web.Controllers
{
    public class ChoreController : Controller
    {
        private readonly IChoreService _service;

        private readonly IUserHistoryService _userhistoryservice;

        private readonly IPersonService _personservice;

        public ChoreController(IChoreService service, IUserHistoryService userHistoryService, IPersonService personService )
        {
            _service = service;
            _userhistoryservice = userHistoryService;
            _personservice = personService;
        }

        public async Task<IActionResult> Index(int id, int idperson)
        {

            var items = await _service.GetAllAsync(id, idperson);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.UserHistories = await _userhistoryservice.GetAllSimpleAsync();
            ViewBag.People = await _personservice.GetAllSimpleAsync();
            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Chore item)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.action = Enumerations.INSERT;
            ViewBag.UserHistories = await _userhistoryservice.GetAllSimpleAsync();
            ViewBag.People = await _personservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Chore item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            ViewBag.UserHistories = await _userhistoryservice.GetAllSimpleAsync();
            ViewBag.People = await _personservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Chore chore)
        {
            if (id != chore.ChoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(chore);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, chore);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

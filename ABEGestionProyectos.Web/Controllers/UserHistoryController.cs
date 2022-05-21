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
    public class UserHistoryController : Controller
    {

        private readonly IUserHistoryService _service;

        private readonly IEpicService _epicservice;

        private readonly ISprintService _sprintservice;

        public UserHistoryController(IUserHistoryService Service, IEpicService epicService, ISprintService sprintService)
        {
            _service = Service;
            _epicservice = epicService;
            _sprintservice = sprintService;
        }

        public async Task<IActionResult> Index(int id, int idsprint)
        {
            //ViewBag.ID = id;
            //ViewBag.Sprints = await _sprintservice.GetAllSimpleAsync();

            var items = await _service.GetAllAsync(id, idsprint);
           // var itemss = await _service.GetAllAsyncs(id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Epics = await _epicservice.GetAllSimpleAsync();
            ViewBag.Sprints = await _sprintservice.GetAllSimpleAsync();
            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserHistory item)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.action = Enumerations.INSERT;
            ViewBag.Epics = await _epicservice.GetAllSimpleAsync();
            ViewBag.Sprints = await _sprintservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            UserHistory item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Epics = await _epicservice.GetAllSimpleAsync();
            ViewBag.Sprints = await _sprintservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserHistory userHistory)
        {
            if (id != userHistory.UserHistoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(userHistory);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, userHistory);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

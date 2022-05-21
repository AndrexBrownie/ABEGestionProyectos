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
    public class SprintController : Controller
    {
        private readonly ISprintService _service;

        public SprintController(ISprintService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Sprint item)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL, item);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Sprint item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            return View(Enumerations.DETAIL, item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sprint sprint)
        {
            if (id != sprint.SprintID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(sprint);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, sprint);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

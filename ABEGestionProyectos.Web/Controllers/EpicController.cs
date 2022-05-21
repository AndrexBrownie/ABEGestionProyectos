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
    public class EpicController : Controller
    {
        private readonly IEpicService _service;

        private readonly IProjectService _projectservice;

        public EpicController(IEpicService Service, IProjectService projectService)
        {
            _service = Service;
            _projectservice = projectService;
        }

        public async Task<IActionResult> Index(int id)
        {
            //pasa id y nombre de proyecto
            ViewBag.ID = id;
            ViewBag.Projects = await _projectservice.GetAllSimpleAsync();

            var items = await _service.GetAllAsync(id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Projects = await _projectservice.GetAllSimpleAsync();
            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Epic item)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.action = Enumerations.INSERT;
            ViewBag.Projects = await _projectservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Epic item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Projects = await _projectservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Epic epic)
        {
            if (id != epic.EpicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(epic);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, epic);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

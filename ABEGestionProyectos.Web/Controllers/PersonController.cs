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
    public class PersonController : Controller
    {

        private readonly IPersonService _service;

        private readonly IRoleService _roleservice;

        public PersonController(IPersonService Service, IRoleService roleService)
        {
            _service = Service;
            _roleservice = roleService;
        }

        public async Task< IActionResult> Index(int id)
        {
            //pasa id y nombre de rol
            ViewBag.ID = id;
            ViewBag.Roles = await _roleservice.GetAllSimpleAsync();

            var items = await _service.GetAllAsync(id);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = await _roleservice.GetAllSimpleAsync();
            ViewBag.action = Enumerations.INSERT;
            return View(Enumerations.DETAIL);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Person item)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.action = Enumerations.INSERT;
            ViewBag.Roles = await _roleservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Person item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            ViewBag.Roles = await _roleservice.GetAllSimpleAsync();
            return View(Enumerations.DETAIL, item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person )
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(person);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, person);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

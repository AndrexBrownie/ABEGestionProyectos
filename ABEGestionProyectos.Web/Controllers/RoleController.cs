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
    public class RoleController : Controller
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
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
        [ValidateAntiForgeryToken] //proteccion frente a ataques mal intencionados o falsicicacion de peticion en sitios cruzados
        public async Task<IActionResult> Add(Role item)
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

            Role item = await _service.GetAsync(id);
            ViewBag.action = Enumerations.UPDATE;

            if (item == null)
            {
                return NotFound();
            }

            return View(Enumerations.DETAIL, item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            if (id != role.RoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _service.EditAsync(role);
                return RedirectToAction(nameof(Index));
            }

            return View(Enumerations.DETAIL, role);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

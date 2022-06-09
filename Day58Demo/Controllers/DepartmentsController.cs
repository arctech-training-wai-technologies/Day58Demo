using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day58Demo.Models;
using Day58Demo.Models.Data;
using Day58Demo.Models.Services;

namespace Day58Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departmentService = new DepartmentService();
            var departments = await departmentService.GetAllAsync();

            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                var departmentService = new DepartmentService();
                await departmentService.CreateAsync(department);

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                var departmentService = new DepartmentService();
                var state = await departmentService.UpdateAsync(department);

                if (state)
                    return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var departmentService = new DepartmentService();
            var department = await departmentService.GetByIdAsync(id);

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentService = new DepartmentService();
            try
            {
                await departmentService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return Problem("Entity set 'ApplicationDbContext.Departments'  is null.");
            }
        }
    }
}

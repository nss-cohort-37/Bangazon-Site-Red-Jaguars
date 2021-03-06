﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bangazon.Models.ViewModels;

namespace Bangazon.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductTypesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ProductTypeViewModel();


            model.Types = await _context
                .ProductType
                .Select(pt => new TypeWithProduct()
                {
                    TypeId = pt.ProductTypeId,
                    TypeName = pt.Label,
                    ProductCount = pt.Products.Count(),
                    Products = pt.Products.OrderByDescending(p => p.DateCreated).Take(3).ToList()
                }).ToListAsync();

            return View(model);
        }

        // GET: ProductType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CategoryStorer _categoryStorer;
        private readonly IRepository<Category>  _categoryRepository;
        public CategoryController(CategoryStorer categoryStorer,
            IRepository<Category> categoryRepository)
        {
            _categoryStorer = categoryStorer;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.All();

            var viewModels = categories.Select(c => new CategoryViewModel{Id = c.Id, Name = c.Name});

            return View(viewModels);
        }
 
        public IActionResult CreateOrEdit(int id)
        {

            if (id > 0)
            {
                var category = _categoryRepository.GetById(id);

                var categoryViewModel  = category != null ? new CategoryViewModel { Id = category.Id, Name = category.Name } : null;

                return View(categoryViewModel);                
            }
            else return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit([FromForm]CategoryViewModel viewModel)
        {
            _categoryStorer.Store(viewModel.Id, viewModel.Name);
            return View();
        }
    }
}

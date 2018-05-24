using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Web.Models;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly SaleFactory _salefactory;
        private readonly IRepository<Product>  _productRepository;
        public SaleController(SaleFactory saleFactory,
            IRepository<Product> productRepository)
        {
            _salefactory = saleFactory;
            _productRepository = productRepository;
        }

        public IActionResult Create()
        {
            return View(ProductList());
        }

        [HttpPost]
        public IActionResult Create([FromForm]SaleViewModel viewModel)
        {
            _salefactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            return Ok();
        }

        private SaleViewModel ProductList()
        {
             var products = _productRepository.All();
            if (products.Any())
            {
                var productsViewModel = products.Select(c => new ProductViewModel{Id = c.Id, Name = c.Name});
            
                return new SaleViewModel{Products = productsViewModel};    
            }
            return new SaleViewModel{Products = new List<ProductViewModel>()};    
        }
    }
}

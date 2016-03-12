using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Core.Products;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Market.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Dashboard()
        {
            var viewModel = new DashboardViewModel();
            return View("Dashboard", viewModel);
        }

        public IActionResult CreateProduct()
        {
            var viewModel = new CreateProductModel();
            return View("CreateProduct", viewModel);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductModel model)
        {
            _productService.Create(model);
            return View("CreateProduct", model);
        }
    }

    public class DashboardViewModel
    {
    }
}

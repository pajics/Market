using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Market.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            var viewModel = new ProductViewModel();
            return View("Index", viewModel);
        }
    }

    public class ProductViewModel
    {
    }
}

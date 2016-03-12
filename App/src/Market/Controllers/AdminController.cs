using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Market.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public IActionResult Dashboard()
        {
            var viewModel = new DashboardViewModel();
            return View("Dashboard", viewModel);
        }
    }

    public class DashboardViewModel
    {
    }
}

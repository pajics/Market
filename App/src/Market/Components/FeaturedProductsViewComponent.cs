using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.ViewModels.Components;
using Microsoft.AspNet.Mvc;

namespace Market.Components
{
    public class FeaturedProductsViewComponent  : ViewComponent
    {
        public FeaturedProductsViewComponent ()
        {
            
        }

        public IViewComponentResult Invoke()
        {
            return View(new FeaturedProductViewModel());
        }
    }
}

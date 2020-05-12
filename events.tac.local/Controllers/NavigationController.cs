using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationBuilder builder;

        public NavigationController() : this(new NavigationBuilder()) { }

        public NavigationController(NavigationBuilder builder)
        {
            this.builder = builder;
        }
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(builder.Build());
        }
    }
}
using events.tac.local.Business;
using Sitecore.Shell.Framework.Commands.TemplateBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        private readonly BreadcrumbBuilder builder;

        public BreadcrumbController() :  this(new BreadcrumbBuilder()) { }

        public BreadcrumbController(BreadcrumbBuilder builder)
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
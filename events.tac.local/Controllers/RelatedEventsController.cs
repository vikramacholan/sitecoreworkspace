using events.tac.local.Business;
using Sitecore.Shell.Framework.Commands.TemplateBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        private readonly RelatedEventsProvider provider;

        public RelatedEventsController() :  this(new RelatedEventsProvider()) { }

        public RelatedEventsController(RelatedEventsProvider builder)
        {
            this.provider = builder;
        }
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(provider.GetRelatedEvents());
        }
    }
}
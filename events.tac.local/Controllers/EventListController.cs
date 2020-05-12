using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventListController : Controller
    {
        private readonly EventProvider builder;

        public EventListController() : this(new EventProvider()) { }

        public EventListController(EventProvider builder)
        {
            this.builder = builder;
        }
        // GET: Breadcrumb
        public ActionResult Index(int page=1)
        {
            return View(builder.GetEventsList(page - 1));
        }
    }
}
﻿using events.tac.local.Models;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class RelatedEventsProvider
    {
        private IRenderingContext renderingContext;

        public RelatedEventsProvider() : this(SitecoreRenderingContext.Create()) { }

        public RelatedEventsProvider(IRenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public IEnumerable<NavigationItem> GetRelatedEvents()
        {
            return this.renderingContext
                .ContextItem
                .GetMultilistFieldItems("RelatedEvents")
                .Select(i => new NavigationItem(
                    title: i.DisplayName,
                    url: i.Url
                    ));
        }
    }
}
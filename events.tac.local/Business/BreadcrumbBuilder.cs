using events.tac.local.Models;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class BreadcrumbBuilder
    {
        private IRenderingContext renderingContext;

        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create()) { }

        public BreadcrumbBuilder(IRenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public IEnumerable<NavigationItem> Build()
        {
            if (this.renderingContext?.HomeItem == null || this.renderingContext?.ContextItem == null)
            {
                return Enumerable.Empty<NavigationItem>();
            }
            else
            {
                return this.renderingContext
                    .ContextItem
                    .GetAncestors()
                    .Where(i => this.renderingContext.HomeItem.IsAncestorOrSelf(i))
                    .Select(i => new NavigationItem
                        (
                            title: i.DisplayName,
                            url: i.Url,
                            isActive: false
                        ))
                    .Concat(
                        new[]
                        {
                            new NavigationItem
                            (
                                title: this.renderingContext.ContextItem.DisplayName,
                                url: this.renderingContext.ContextItem.Url,
                                isActive: true
                                )
                        }
                    );
            }
        }
    }
}
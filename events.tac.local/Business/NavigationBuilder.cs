using events.tac.local.Models;
using Sitecore;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.Interfaces;
using TAC.Sitecore.Abstractions.SitecoreImplementation;

namespace events.tac.local.Business
{
    public class NavigationBuilder
    {
        private IRenderingContext renderingContext;

        public NavigationBuilder() : this(SitecoreRenderingContext.Create()) { }

        public NavigationBuilder(IRenderingContext renderingContext)
        {
            this.renderingContext = renderingContext;
        }

        public NavigationMenuItem Build()
        {
            var root = this.renderingContext?.DatasourceOrContextItem;

            return new NavigationMenuItem(
                   title: root?.DisplayName,
                   url: root?.Url,
                   children: root != null && this.renderingContext.ContextItem != null ? Build(root, this.renderingContext.ContextItem) : null
                );
        }

        private IEnumerable<NavigationMenuItem> Build(IItem node, IItem current)
        {
            return node
                .GetChildren()
                .Select(i => new NavigationMenuItem(
                      title: i?.DisplayName,
                   url: i?.Url,
                   children: Build(i, current) 
                    ));
        }

    }
}
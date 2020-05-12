using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationMenuItem : NavigationItem
    {
        public IEnumerable<NavigationMenuItem> Children { private set; get;}
        public NavigationMenuItem(string title, string url, IEnumerable<NavigationMenuItem> children) : base(title, url, false)
        {
            this.Children = children != null ? children : new List<NavigationMenuItem>();
        }
    }
}
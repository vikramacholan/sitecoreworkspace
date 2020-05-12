using Sitecore.Shell.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class NavigationItem
    {
        public NavigationItem(string title, string url, bool isActive = false)
        {
            this.Title = title;
            this.Url = url;
            this.IsActive = IsActive;
        }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}
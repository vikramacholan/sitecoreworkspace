using events.tac.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Business
{
    public class EventProvider
    {
        private const int PageSize = 4;
        public EventList GetEventsList(int pageNo)
        {
            string indexName = $"events_{RenderingContext.Current.ContextItem.Database.Name.ToLower()}_index";
            ISearchIndex index = ContentSearchManager.GetIndex(indexName);

            using(IProviderSearchContext context = index.CreateSearchContext())
            {
                SearchResults<EventDetails> resuls = context.GetQueryable<EventDetails>()
                    .Where(i => i.Paths.Contains(RenderingContext.Current.ContextItem.ID))
                    .Where(i => i.Language == RenderingContext.Current.ContextItem.Language.Name)
                    .Page(pageNo,PageSize)
                    .GetResults();

                return new EventList()
                {
                    Events = resuls.Hits.Select(h => h.Document).ToArray(),
                    PageSize = PageSize,
                    TotalResultCount = resuls.TotalSearchResults
                };
            }
        }
    }
}
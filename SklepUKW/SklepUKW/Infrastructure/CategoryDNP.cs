using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using SklepUKW.DAL;

namespace SklepUKW.Infrastructure
{
    public class CategoryDNP : DynamicNodeProviderBase
    {
        FilmsContext db = new FilmsContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var categoryDN = new List<DynamicNode>();
            foreach (var cat in db.Categories)
            {
                DynamicNode dn = new DynamicNode()
                {
                    Title = cat.Name,
                    Key = "Category_" + cat.CategoryID
                };
                dn.RouteValues.Add("categoryName", cat.Name); //nazwa arg i jej wartosc

                categoryDN.Add(dn);
            }

            return categoryDN;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using SklepUKW.DAL;

namespace SklepUKW.Infrastructure
{
    public class FilmsDNP : DynamicNodeProviderBase
    {
        FilmsContext db = new FilmsContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            //throw new NotImplementedException();

            var filmsDN = new List<DynamicNode>();
            foreach (var film in db.Films)
            {
                DynamicNode dn = new DynamicNode()
                {
                    Title = film.Title,
                    Key = "Film_" + film.FilmID,
                    ParentKey = "Category_" + film.CategoryID
                };
                dn.RouteValues.Add("id", film.FilmID); //nazwa arg i jej wartosc

                filmsDN.Add(dn);
            }

            return filmsDN;
        }
    }
}

// dziedziczenie
// using
// dodać metodę ienum
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.DAL;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.Infrastructure
{
    public class LokaleSzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ZarzadzanieContext db = new ZarzadzanieContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (LokalMieszkalny lokal in db.LokaleMieszkalne)
            {
                DynamicNode node = new DynamicNode();
                node.Title = lokal.Adres;
                node.Key = "Lokal_" + lokal.LokalID;
                node.ParentKey = "Budynek_" + lokal.BlokMieszkalnyID;
                node.RouteValues.Add("id", lokal.LokalID);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignition.Repo;
using Ignition.Repo.Model;

namespace Ignition.Controllers
{
    public class WorkingZone:Controller
    {
        [HttpGet]
        public  ActionResult Documents(int zoneId, int userId)
        {
            var context = new IgniteDataContext();
            List<string> docs = new List<string>();
            if (zoneId == 1)//zona de lucru
            {
                foreach(var document in context.Documents)
                {
                    if (document.flux == null)
                    {
                        docs.Add(document.name);
                    }
                }
                return View("WorkingZone", docs);
            }
            if(zoneId == 2)//zona cu task-uri initiate
            {
                foreach(var flux in context.Fluxs)
                {
                    docs.Add("FLux: " + flux);
                    foreach(var document in flux.documents)
                    {
                        if(document.signature==-2)//-2 documentul a trecut prin toate fazele din flux; -1 documentul nu a inceput sa fie semnat
                            docs.Add(document.name);
                    }

                }
            }
            if(zoneId == 3)//zona cu task-uri
            {
                foreach(var document in context.Documents)
                {
                    if (document.signature == userId)
                    {
                        docs.Add(document.name);
                    }
                }
            }
            if(zoneId == 4)//zona cu task-uri terminate
            {
                foreach (var flux in context.Fluxs)
                {
                    docs.Add("FLux: " + flux);
                    foreach (var document in flux.documents)
                    {
                        docs.Add(document.name);
                    }

                }
            }
            return View("HomeController", "Invalid zone id");
        }

    }
}
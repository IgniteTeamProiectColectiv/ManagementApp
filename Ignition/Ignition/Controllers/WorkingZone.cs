using System.Collections.Generic;
using System.Web.Mvc;
using Ignition.Repo;

namespace Ignition.Controllers
{
    public class WorkingZone:Controller
    {
        private readonly UnitOfWork _unitOfWork=new UnitOfWork();

        [HttpGet]
        public  ActionResult Documents(int zoneId, int userId)
        {
            List<string> docs = new List<string>();
            if (zoneId == 1)//zona de lucru
            {
                foreach(var document in _unitOfWork.Context.Documents)
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
                foreach(var flux in _unitOfWork.Context.Fluxs)
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
                foreach(var document in _unitOfWork.Context.Documents)
                {
                    if (document.signature == userId)
                    {
                        docs.Add(document.name);
                    }
                }
            }
            if(zoneId == 4)//zona cu task-uri terminate
            {
                foreach (var flux in _unitOfWork.Context.Fluxs)
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
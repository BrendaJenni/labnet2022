using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string eMessage,string cMessage)
        {
            ViewBag.Error = eMessage;
            ViewBag.Message = cMessage;

            return View();
        }
    }
}
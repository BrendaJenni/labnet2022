using DogApiLogic;
using Lab.EF.Entities;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class DogController : Controller
    {
        // GET: Dog
        DogLogic logic = new DogLogic();
        public async Task<ActionResult> Index()
        {
            Dog dogImage = await logic.GetDogs();
            DogView dogView = new DogView()
            {
                Image = dogImage.Message
            };

            return View(dogView);
        }
    }
}
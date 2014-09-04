using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCalculator.Models;

namespace MvcCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            string result = string.Empty;
            switch (model.Action)
            {
                case "+":
                    result = (model.FirstNumber + model.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "-":
                    result = (model.FirstNumber - model.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "*":
                    result = (model.FirstNumber * model.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "/":
                    result = (model.FirstNumber / model.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
            }

            ViewBag.Result = result;

            
            return View();
        }

    }
}

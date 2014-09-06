using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCalculator.Models;

using  Calculator.Core;

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
        public ActionResult Index(CalcViewModel viewModel)
        {
            string result = string.Empty;
            switch (viewModel.Action)
            {
                case "+":
                    result = new CalculationService().Add(viewModel.FirstNumber, viewModel.SecondNumber).ToString();
                //(viewModel.FirstNumber + viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                //case "-":
                //    result = (viewModel.FirstNumber - viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //    break;
                //case "*":
                //    result = (viewModel.FirstNumber * viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //    break;
                //case "/":
                //    result = (viewModel.FirstNumber / viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //    break;
            }

            ViewBag.Result = result;

            
            return View();
        }

    }
}

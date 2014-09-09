using System.Globalization;
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
                    result = new CalculationService().Add(viewModel.FirstNumber, viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //(viewModel.FirstNumber + viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "-":
                    result = new CalculationService().Substract(viewModel.FirstNumber, viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //    result = (viewModel.FirstNumber - viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "*":
                    result = new CalculationService().Multiply(viewModel.FirstNumber, viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                //    result = (viewModel.FirstNumber * viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
                case "/":
                    double divisionResult;
                    result = new CalculationService().TryDivide(viewModel.FirstNumber, viewModel.SecondNumber,
                        out divisionResult) ? divisionResult.ToString(CultureInfo.InvariantCulture) : "Division by zero";
                    //    result = (viewModel.FirstNumber / viewModel.SecondNumber).ToString(CultureInfo.InvariantCulture);
                    break;
            }

            ViewBag.Result = result;

            
            return View();
        }

    }
}

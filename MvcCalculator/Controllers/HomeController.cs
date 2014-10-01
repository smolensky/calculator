using System.Globalization;
using System.Web.Mvc;
using Calculator.Repo;
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
            var calculationService = new LoggingCalculationService(
                        new CalculationService(),
                        new CalculationHistoryRepo());

            string result = string.Empty;

            switch (viewModel.Action)
            {
                case "+":
                    result = calculationService.Add(viewModel.FirstNumber, viewModel.SecondNumber)
                        .ToString(CultureInfo.InvariantCulture);
                    break;
                case "-":
                    result = calculationService.Substract(viewModel.FirstNumber, viewModel.SecondNumber)
                        .ToString(CultureInfo.InvariantCulture);
                    break;
                case "*":
                    result = calculationService.Multiply(viewModel.FirstNumber, viewModel.SecondNumber)
                        .ToString(CultureInfo.InvariantCulture);
                    break;
                case "/":
                    double divisionResult;
                    result = calculationService.TryDivide(viewModel.FirstNumber, viewModel.SecondNumber,
                        out divisionResult) ? divisionResult.ToString(CultureInfo.InvariantCulture) : "Division by zero";
                    break;
            }

            ViewBag.Result = result;

            
            return View();
        }

    }
}

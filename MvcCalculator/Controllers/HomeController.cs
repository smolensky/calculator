using System.Globalization;
using System.Web.Mvc;
using Calculator.Repo;
using Calculator.Repo.Abstract;
using Calculator.Repo.EntityFramework;
using MvcCalculator.Models;

using  Calculator.Core;

namespace MvcCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculationHistoryRepo _calculationHistoryRepo
            = new EntityFrameworkCalculationHistoryRepo();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CalculationHistory = _calculationHistoryRepo.Load();
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalcViewModel viewModel)
        {
            
            var calculationService = new LoggingCalculationService(
                        new CalculationService(),
                        _calculationHistoryRepo);

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
                    double? divisionResult;
                    result = calculationService.TryDivide(viewModel.FirstNumber, viewModel.SecondNumber,
                        out divisionResult) ? divisionResult.ToString() : "Division by zero";
                    break;
            }

            ViewBag.CalculationResult = result;

            ViewBag.CalculationHistory = _calculationHistoryRepo.Load();

            return View();
        }

    }
}

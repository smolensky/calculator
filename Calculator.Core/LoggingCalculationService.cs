using Calculator.Entities;
using Calculator.Repo;
using Calculator.Repo.Abstract;

namespace Calculator.Core
{
    public class LoggingCalculationService : ICalculationService
    {
        private readonly ICalculationService _core;
        private readonly ICalculationHistoryRepo _repo;

        public LoggingCalculationService(ICalculationService core, 
            ICalculationHistoryRepo repo)
        {
            _core = core;
            _repo = repo;
        }

        public double Add(double firstNumber, double secondNumber)
        {
            var result = _core.Add(firstNumber, secondNumber);

            _repo.Save(new CalculationActionDto(firstNumber, secondNumber, ActionType.Plus, result));

            return result;
        }

        public double Substract(double firstNumber, double secondNumber)
        {
            var result = _core.Substract(firstNumber, secondNumber);

            _repo.Save(new CalculationActionDto(firstNumber, secondNumber, ActionType.Minus, result));

            return result;
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            var result = _core.Multiply(firstNumber, secondNumber);

            _repo.Save(new CalculationActionDto(firstNumber, secondNumber, ActionType.Multiply, result));

            return result;
        }

        public bool TryDivide(double firstNumber, double secondNumber, out double? result)
        {
            bool divisionSucceeded = _core.TryDivide(firstNumber, secondNumber, out result);

            _repo.Save(new CalculationActionDto(firstNumber, secondNumber, ActionType.Divide, result));

            return divisionSucceeded;
        }
    }
}
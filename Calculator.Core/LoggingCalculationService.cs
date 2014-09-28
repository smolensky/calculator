using Calculator.Entities;
using Calculator.Repo;

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
            double result = _core.Add(firstNumber, secondNumber);

            _repo.Save(new CalculationActionDto(firstNumber, secondNumber, ActionType.Plus, result));

            return result;
        }

        public double Substract(double firstNumber, double secondNumber)
        {
            throw new System.NotImplementedException();
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            throw new System.NotImplementedException();
        }

        public bool TryDivide(double firstNumber, double secondNumber, out double result)
        {
            throw new System.NotImplementedException();
        }
    }
}
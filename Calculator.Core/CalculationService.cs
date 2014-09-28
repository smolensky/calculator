namespace Calculator.Core
{
    public class CalculationService : ICalculationService
    {
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Substract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public bool TryDivide(double firstNumber, double secondNumber, out double result)
        {
            if (secondNumber != 0)
            {
                result = firstNumber/secondNumber;

                return true;
            }

            result = 0;

            return false;
        }
    }
}
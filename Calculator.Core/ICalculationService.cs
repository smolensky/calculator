namespace Calculator.Core
{
    public interface ICalculationService
    {
        double Add(double firstNumber, double secondNumber);
        double Substract(double firstNumber, double secondNumber);
        double Multiply(double firstNumber, double secondNumber);
        bool TryDivide(double firstNumber, double secondNumber, out double result);
    }
}
namespace Calculator.Entities
{
    public class CalculationActionDto
    {
        public CalculationActionDto(double firstNumber,
            double secondNumber,
            ActionType actionType,
            double result)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            ActionType = actionType;
            Result = result;
        }

        public double FirstNumber { get; private set; }

        public double SecondNumber { get; private set; }

        public ActionType ActionType { get; private set; }

        public double Result { get; private set; }
    }
}
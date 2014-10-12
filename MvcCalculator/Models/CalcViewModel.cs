namespace MvcCalculator.Models
{
    public class CalcViewModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public string Action { get; set; }
        public double? Result { get; set; }
    }
}
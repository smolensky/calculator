using Xunit;

namespace stresscalc.Tests
{
    public class CalculatorTests
    {
        [Fact]
        private void Should_substract_second_number_from_first_number_Always()
        {
            // Arrange
            var calculator = new Calculator.Core.CalculationService();

            // Act
            double actual = calculator.Substract(10, 3);

            // Assert
            Assert.Equal(7, actual);
        }

        [Fact]
        private void Should_divide_first_number_by_second_number_When_second_number_is_not_zero()
        {
            // Arrange
            
            double actual;

            var calculator = new Calculator.Core.CalculationService();

            // Act
            calculator.TryDivide(10, 5, out actual);

            // Assert
            Assert.Equal(2, actual);
           
        }

        [Fact]
        private void Should_return_true_when_Divide_method_called_and_second_number_is_not_zero()
        {
            // Arrange
            bool isDivisible;
            double actual;

            var calculator = new Calculator.Core.CalculationService();

            // Act
            isDivisible = calculator.TryDivide(10, 5, out actual);

            // Assert
             Assert.Equal(true, isDivisible);
        }

        // TODO: all other methods, check for zero case for division


    }
}

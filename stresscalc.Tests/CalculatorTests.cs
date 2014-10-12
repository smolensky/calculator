using Calculator.Core;
using Xunit;

namespace stresscalc.Tests
{
    public class CalculatorTests
    {
        private readonly CalculationService  _calculator = new CalculationService();
        double? _actual;
        [Fact]
        private void Should_substract_second_number_from_first_number_Always()
        {
            Assert.Equal(2.2, _calculator.Substract(5.5, 3.3));
        }

        [Fact]
        private void Should_add_second_number_to_first_number_Always()
        {
            Assert.Equal(13, _calculator.Add(10, 3));
        }

        [Fact]
        private void Should_multiply_first_number_on_second_number_Always()
        {
            Assert.Equal(30, _calculator.Multiply(10, 3));
        }

        [Fact]
        private void Should_divide_first_number_by_second_number_When_second_number_is_not_zero()
        {
            _calculator.TryDivide(10, 4, out _actual);

            Assert.Equal(2.5, _actual);
        }

        [Fact]
        private void Should_return_true_when_Divide_method_called_and_second_number_is_not_zero()
        {
             Assert.Equal(true, _calculator.TryDivide(10, 5, out _actual));
        }

        [Fact]
        private void Should_return_false_when_Divide_method_called_and_second_number_is_zero()
        {
            Assert.Equal(false, _calculator.TryDivide(10, 0, out _actual));
        }

        [Fact]
        private void Should_return_null_When_second_number_is_zero()
        {
            _calculator.TryDivide(10, 0, out _actual);

            Assert.Equal(null, _actual);
        }
    }
}

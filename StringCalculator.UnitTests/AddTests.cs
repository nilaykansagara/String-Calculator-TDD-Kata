using Xunit;
using FluentAssertions;

namespace StringCalculator.UnitTests
{
    public class AddTests
    {
        private readonly StringCalculator _stringCalculator;

        public AddTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            // Act
            var result = _stringCalculator.Add("");

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_SingleNumber_ReturnsSameNumber(string number, int sum)
        {
            // Act
            var result = _stringCalculator.Add(number);

            // Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5,7", 15)]
        [InlineData("9,0,9,9,0,9,0,9", 45)]
        public void Add_MultipleNumbers_ReturnsSumOfAllNumbers(string numbers, int sum)
        {
            // Act
            var result = _stringCalculator.Add(numbers);

            // Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        public void Add_NewLineDelimiter_ReturnsSumOfNumbers(string numbers, int sum)
        {
            // Act
            var result = _stringCalculator.Add(numbers);

            // Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("//;\n3;4", 7)]
        [InlineData("//^\n2^3^5", 10)]
        public void Add_DifferentDelimiter_ReturnsCorrectSum(string numbers, int sum)
        {
            // Act
            var result = _stringCalculator.Add(numbers);

            // Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("-1", "Negative numbers not allowed: -1")]
        [InlineData("-1,2,-3,4,-5", "Negative numbers not allowed: -1,-3,-5")]
        public void Add_NegativeNumbers_ThrowsExceptionWithNegativeNumbersInErrorMessage(string numbers, string errorMessage)
        {
            // Act
            Action result = () => _stringCalculator.Add(numbers);

            // Assert
            result.Should().Throw<Exception>().WithMessage(errorMessage);
        }

        [Theory]
        [InlineData("1001,12", 12)]
        [InlineData("1000,15", 1015)]
        [InlineData("1000,1000,1001,1", 2001)]
        public void Add_BiggerThan1000_IgnoresNumber(string numbers, int sum)
        {
            // Act
            var result = _stringCalculator.Add(numbers);

            // Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("//[*]\n1*2*3", 6)]
        [InlineData("//[*^*]\n1*^*2*^*3", 6)]
        [InlineData("//[!*^*!]\n1!*^*!2!*^*!3", 6)]
        public void Add_AnyLengthDelimiter_ReturnsCorrectSum(string numbers, int sum)
        {
            // Act
            var result = _stringCalculator.Add(numbers);

            // Assert
            result.Should().Be(sum);
        }
    }
}

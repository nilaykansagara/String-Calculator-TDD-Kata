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
    }
}

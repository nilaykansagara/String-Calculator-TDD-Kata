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

        [Fact]
        public void Add_StringWithSingleNumber_ReturnsSameNumber()
        {
            // Act
            var result = _stringCalculator.Add("1");

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void Add_StringWithTwoNumbers_ReturnsSumOfBothNumbers()
        {
            // Act
            var result = _stringCalculator.Add("1,2");

            // Assert
            result.Should().Be(3);
        }
    }
}

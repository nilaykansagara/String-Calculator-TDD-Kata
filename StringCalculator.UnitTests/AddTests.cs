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
    }
}

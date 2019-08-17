using System.Linq;
using FluentAssertions;
using RussianPeasantMultiplication.Calculation;
using Xunit;

namespace RussianPeasantMultiplication.Tests
{
    public class MultiplierTest
    {
        private readonly IMultiplier multiplier = new RussianPeasantMultiplier();

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        public void Multiply_OutputsInputAsFirstLine(int a, int b)
        {
            var result = multiplier.Multiply(a, b);
            
            result.Steps
                .Should().HaveCount(1, "left operand is already 1");

            result.Steps.Single().left
                .Should().Be(a, "the input should be the first line of output");
            result.Steps.Single().right
                .Should().Be(b, "the input should be the first line of output");
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 3)]
        [InlineData(12, 3, 36)]
        public void Multiply_CalculatesResultCorrectly(int a, int b, int expected) {
            multiplier.Multiply(a, b).Result
                .Should().Be(expected);
        }

        [Fact]
        public void Multiply_PerformsOneStepThenStops() {
            var result = multiplier.Multiply(2, 3);

            result.Steps.Should().HaveCount(2);

            result.Steps[0].left
                .Should().Be(2);
            result.Steps[0].right
                .Should().Be(3);

            result.Steps[1].left
                .Should().Be(1);
            result.Steps[1].right
                .Should().Be(6);
        }

        [Fact]
        public void Multiply_CrossesOutIfLeftIsEven() {
            var result = multiplier.Multiply(12, 3);

            result.Steps.Should().HaveCount(4);

            result.Steps[0].Should().Be((12, 3, false));
            result.Steps[1].Should().Be((6, 6, false));
            result.Steps[2].Should().Be((3, 12, true));
            result.Steps[3].Should().Be((1, 24, true));
        }
    }
}

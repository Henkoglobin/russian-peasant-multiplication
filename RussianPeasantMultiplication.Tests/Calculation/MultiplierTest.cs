using System;
using System.Linq;
using FluentAssertions;
using RussianPeasantMultiplication.Calculation;
using RussianPeasantMultiplication.Model;
using Xunit;

namespace RussianPeasantMultiplication.Tests.Calculation {
    public class MultiplierTest {
        private readonly IMultiplier multiplier = new RussianPeasantMultiplier();

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        public void Multiply_OutputsInputAsFirstLine(int a, int b) {
            var result = multiplier.Multiply(a, b);

            result.Steps
                .Should().HaveCount(1, "left operand is already 1");

            result.Steps.Single().Left
                .Should().Be(a, "the input should be the first line of output");
            result.Steps.Single().Right
                .Should().Be(b, "the input should be the first line of output");
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 3)]
        [InlineData(12, 3, 36)]
        [InlineData(3, 7, 21)]
        [InlineData(5, 3, 15)]
        public void Multiply_CalculatesResultCorrectly(
            int a,
            int b,
            int expected
        ) {
            multiplier.Multiply(a, b).Result
                .Should().Be(expected);
        }

        [Theory]
        [InlineData(-1, 12, -12)]
        [InlineData(-2, 6, -12)]
        [InlineData(2, -6, -12)]
        [InlineData(-2, -6, 12)]
        public void Multiply_HandlesNegativeValuesCorrectly(
            int a,
            int b,
            int expected
        ) {
            multiplier.Multiply(a, b).Result
                .Should().Be(expected);
        }

        [Fact]
        public void Multiply_CrossesOutIfLeftIsEven() {
            var result = multiplier.Multiply(12, 3);

            result.Steps.Should().HaveCount(4);

            result.Steps[0].Should().BeEquivalentTo(new MultiplicationStep(12, 3, false));
            result.Steps[1].Should().BeEquivalentTo(new MultiplicationStep(6, 6, false));
            result.Steps[2].Should().BeEquivalentTo(new MultiplicationStep(3, 12, true));
            result.Steps[3].Should().BeEquivalentTo(new MultiplicationStep(1, 24, true));
        }

        [Fact]
        public void Multiply_PerformsOneStepThenStops() {
            var result = multiplier.Multiply(2, 3);

            result.Steps.Should().HaveCount(2);

            result.Steps[0].Left
                .Should().Be(2);
            result.Steps[0].Right
                .Should().Be(3);

            result.Steps[1].Left
                .Should().Be(1);
            result.Steps[1].Right
                .Should().Be(6);
        }

        [Fact]
        public void Multiply_TerminatesForZeroInput() {
            multiplier.ExecutionTimeOf(m => m.Multiply(0, 120))
                .Should().BeLessThan(TimeSpan.FromMilliseconds(10));
        }
    }
}

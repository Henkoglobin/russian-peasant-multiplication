using System.Collections.Generic;
using FluentAssertions;
using RussianPeasantMultiplication.Formatting;
using RussianPeasantMultiplication.Model;
using Xunit;

namespace RussianPeasantMultiplication.Tests.Formatting {
    public class MultiplicationResultFormatterTest {
        private readonly IMultiplicationResultFormatter formatter = new MultiplicationResultFormatter();

        [Fact]
        public void Format_OutputStartsWithInput() {
            var resultString = formatter.FormatToString(
                new MultiplicationResult(
                    1,
                    2,
                    2,
                    new List<MultiplicationStep>() {
                        new MultiplicationStep(1, 2, true)
                    }
                )
            );

            resultString.Should().StartWith("1 * 2\n=====\n",
                "the input must be printed at the beginning, followed by a delimiter");
        }

        [Fact]
        public void Format_PrintsResultAtEnd() {
            var resultString = formatter.FormatToString(
                new MultiplicationResult(
                    1,
                    2,
                    2,
                    new List<MultiplicationStep>() {
                        new MultiplicationStep(1, 2, true)
                    }
                )
            );

            resultString.Should().EndWith("\n=====\n    2", "the result must be printed at the end, preceded by a delimiter");
        }

        [Fact]
        public void Format_LeavesEnoughSpaceForLargerNumbers() {
            var resultString = formatter.FormatToString(
                new MultiplicationResult(
                    128,
                    2,
                    256,
                    new List<MultiplicationStep>() {
                        new MultiplicationStep(128, 2, false),
                        new MultiplicationStep(64, 4, false),
                        new MultiplicationStep(32, 8, false),
                        new MultiplicationStep(16, 16, false),
                        new MultiplicationStep(8, 32, false),
                        new MultiplicationStep(4, 64, false),
                        new MultiplicationStep(2, 128, false),
                        new MultiplicationStep(1, 256, true)
                    }
                )
            );

            resultString.Should().StartWith("128 *   2\n=========\n");
            resultString.Should().EndWith("      256");
        }

        [Fact]
        public void Format_ContainsAllSteps() {
            var resultString = formatter.FormatToString(
                new MultiplicationResult(
                    128,
                    2,
                    256,
                    new List<MultiplicationStep>() {
                        new MultiplicationStep(128, 2, false),
                        new MultiplicationStep(64, 4, false),
                        new MultiplicationStep(32, 8, false),
                        new MultiplicationStep(16, 16, false),
                        new MultiplicationStep(8, 32, false),
                        new MultiplicationStep(4, 64, false),
                        new MultiplicationStep(2, 128, false),
                        new MultiplicationStep(1, 256, true)
                    }
                )
            );

            resultString.Should().Contain("\n128     2\n");
            resultString.Should().Contain("\n 64     4\n");
            resultString.Should().Contain("\n 32     8\n");
            resultString.Should().Contain("\n 16    16\n");
            resultString.Should().Contain("\n  8    32\n");
            resultString.Should().Contain("\n  4    64\n");
            resultString.Should().Contain("\n  2   128\n");
            resultString.Should().Contain("\n  1   256\n");
        }

        [Fact]
        public void Format_HandlesNegativeValues() {
            var resultString = formatter.FormatToString(
                new MultiplicationResult(
                    -128,
                    2,
                    -256,
                    new List<MultiplicationStep>() {
                        new MultiplicationStep(-128, 2, false),
                        new MultiplicationStep(-64, 4, false),
                        new MultiplicationStep(-32, 8, false),
                        new MultiplicationStep(-16, 16, false),
                        new MultiplicationStep(-8, 32, false),
                        new MultiplicationStep(-4, 64, false),
                        new MultiplicationStep(-2, 128, false),
                        new MultiplicationStep(-1, 256, true)
                    }
                )
            );

            resultString.Should().StartWith("-128 *   2\n");
            resultString.Should().Contain("\n-128     2\n");
            resultString.Should().Contain("\n -64     4\n");
            resultString.Should().Contain("\n -32     8\n");
            resultString.Should().Contain("\n -16    16\n");
            resultString.Should().Contain("\n  -8    32\n");
            resultString.Should().Contain("\n  -4    64\n");
            resultString.Should().Contain("\n  -2   128\n");
            resultString.Should().Contain("\n  -1   256\n");
            resultString.Should().EndWith("\n      -256");
        }
    }
}

using System.Linq;
using RussianPeasantMultiplication.Extensions;
using RussianPeasantMultiplication.Model;

namespace RussianPeasantMultiplication.Formatting {
    public class MultiplicationResultFormatter : IMultiplicationResultFormatter {
        public string FormatToString(MultiplicationResult result) {
            var leftColumnWidth = result.LeftInput.ToString().Length;
            var rightColumnWidth = result.Steps.Last().Right.ToString().Length;

            return FormatInputLine(result.LeftInput, result.RightInput, leftColumnWidth, rightColumnWidth) + "\n"
                + Repeat('=', leftColumnWidth + rightColumnWidth + 3) + "\n"
                + result.Steps
                    .Select(step => FormatStepLine(step.Left, step.Right, leftColumnWidth, rightColumnWidth))
                    .JoinToString("\n") + "\n"
                + Repeat('=', leftColumnWidth + rightColumnWidth + 3) + "\n"
                + FormatResultLine(result.Result, leftColumnWidth, rightColumnWidth)
                ;
        }
        
        private string FormatInputLine(
            int left, int right,
            int leftWidth, int rightWidth
        ) => FormatLineImpl(left, right, leftWidth, rightWidth, " * ");

        private string FormatStepLine(
            int left, int right,
            int leftWidth, int rightWidth
        ) => FormatLineImpl(left, right, leftWidth, rightWidth, "   ");

        private string FormatResultLine(
            int result, int leftWidth,
            int rightWidth
        ) => result.ToString().PadLeft(leftWidth + rightWidth + 3);

        private string FormatLineImpl(
            int left, int right,
            int leftWidth, int rightWidth,
            string spacer
        ) => left.ToString().PadLeft(leftWidth) + spacer + right.ToString().PadLeft(rightWidth);

        private string Repeat(char character, int count)
            => Enumerable.Repeat(character, count).JoinToString();
    }
}

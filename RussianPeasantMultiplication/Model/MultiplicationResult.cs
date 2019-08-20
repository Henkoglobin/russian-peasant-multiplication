using System.Collections.Generic;

namespace RussianPeasantMultiplication.Model {
    public class MultiplicationResult {
        public int LeftInput { get; }
        public int RightInput { get; }
        public int Result { get; }
        public IReadOnlyList<MultiplicationStep> Steps { get; }

        public MultiplicationResult(
            int leftInput, 
            int rightInput, 
            int result, 
            IReadOnlyList<MultiplicationStep> steps
        ) {
            LeftInput = leftInput;
            RightInput = rightInput;
            Result = result;
            Steps = steps;
        }
    }
}

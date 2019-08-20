namespace RussianPeasantMultiplication.Model {
    public class MultiplicationStep {
        public int Left { get; }
        public int Right { get; }
        public bool IncludedInSum { get; }

        public MultiplicationStep(
            int left,
            int right,
            bool includedInSum
        ) {
            Left = left;
            Right = right;
            IncludedInSum = includedInSum;
        }
    }
}

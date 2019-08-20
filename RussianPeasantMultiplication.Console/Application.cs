using RussianPeasantMultiplication.Calculation;
using RussianPeasantMultiplication.Formatting;

namespace RussianPeasantMultiplication.Console {
    /// <summary>
    /// Provides a more convenient entry point for the application.
    /// This class supports constructor dependency injection and
    /// offers a single <see cref="Run"/> method that's invoked
    /// with the parameters passed on the command line.
    /// </summary>
    class Application {
        private readonly IMultiplier multiplier;
        private readonly IMultiplicationResultFormatter formatter;

        public Application(
            IMultiplier multiplier,
            IMultiplicationResultFormatter formatter
        ) {
            this.multiplier = multiplier;
            this.formatter = formatter;
        }

        internal void Run(int left, int right) {
            System.Console.WriteLine(
                formatter.FormatToString(
                    multiplier.Multiply(left, right)
                )
            );
        }
    }
}

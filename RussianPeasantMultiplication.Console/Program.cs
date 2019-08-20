using Microsoft.Extensions.DependencyInjection;
using RussianPeasantMultiplication.Calculation;
using RussianPeasantMultiplication.Formatting;

namespace RussianPeasantMultiplication.Console {
    /// <summary>
    /// The main entry point for the application.
    /// This project uses the DragonFruit application model
    /// (https://github.com/dotnet/command-line-api/wiki/DragonFruit-overview)
    /// in order to provide a strongly-types main method.
    /// </summary>
    class Program {
        /// <summary>
        /// Multiplies two numbers via the Russian Peasant Multiplication algorithm.
        /// This program will output the steps performed during the calculation.
        /// </summary>
        /// <param name="left">The first operand.</param>
        /// <param name="right">The second operand.</param>
        static void Main(int left, int right) {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            serviceCollection.BuildServiceProvider()
                .GetRequiredService<Application>()
                .Run(left, right);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<IMultiplier, RussianPeasantMultiplier>()
                .AddTransient<IMultiplicationResultFormatter, MultiplicationResultFormatter>()
                .AddSingleton<Application>()
            ;
    }
}

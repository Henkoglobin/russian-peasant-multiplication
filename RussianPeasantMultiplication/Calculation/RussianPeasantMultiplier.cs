using System.Collections.Generic;
using System.Linq;
using RussianPeasantMultiplication.Model;

namespace RussianPeasantMultiplication.Calculation
{
    public class RussianPeasantMultiplier : IMultiplier
    {
        public MultiplicationResult Multiply(int a, int b)
        {
            var steps = CalculateSteps(a, b).ToList();
            return new MultiplicationResult {
                Result = steps.Where(step => step.includedInSum).Sum(step => step.right),
                Steps = steps
            };
        }

        private IEnumerable<(int left, int right, bool includedInSum)> CalculateSteps(int a, int b)
        {
            while(true) {
                yield return (a, b, a % 2 == 1);

                if(a == 1) yield break;

                a /= 2;
                b *= 2;
            }
        }
    }
}
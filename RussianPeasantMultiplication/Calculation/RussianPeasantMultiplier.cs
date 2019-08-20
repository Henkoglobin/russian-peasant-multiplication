using System;
using System.Collections.Generic;
using System.Linq;
using RussianPeasantMultiplication.Model;

namespace RussianPeasantMultiplication.Calculation {
    public class RussianPeasantMultiplier : IMultiplier {
        public MultiplicationResult Multiply(int a, int b) {
            var steps = CalculateSteps(a, b).ToList();
            return new MultiplicationResult(
                a,
                b,
                steps
                    .Where(step => step.includedInSum)
                    .Sum(step => step.right) * Math.Sign(a),
                steps
                    .Select(step => new MultiplicationStep(step.left, step.right, step.includedInSum))
                    .ToList()
            );
        }

        private IEnumerable<(int left, int right, bool includedInSum)> CalculateSteps(int a, int b) {
            if (a == 0 || b == 0) {
                yield return (a, b, false);
                yield break;
            }

            while (true) {
                yield return (a, b, Math.Abs(a) % 2 == 1);

                if (Math.Abs(a) == 1) {
                    yield break;
                }

                a /= 2;
                b *= 2;
            }
        }
    }
}

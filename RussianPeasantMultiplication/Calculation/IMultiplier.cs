using RussianPeasantMultiplication.Model;

namespace RussianPeasantMultiplication.Calculation {
    public interface IMultiplier {
        MultiplicationResult Multiply(int a, int b);
    }
}

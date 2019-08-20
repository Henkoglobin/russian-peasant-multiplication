using RussianPeasantMultiplication.Model;

namespace RussianPeasantMultiplication.Formatting {
    public interface IMultiplicationResultFormatter {
        string FormatToString(MultiplicationResult result);
    }

}

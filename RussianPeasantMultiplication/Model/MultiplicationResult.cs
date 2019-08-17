using System.Collections.Generic;

namespace RussianPeasantMultiplication.Model
{
    public class MultiplicationResult {
        public int Result { get; set; }
        public List<(int left, int right, bool includedInSum)> Steps { get; set; }
    }
}
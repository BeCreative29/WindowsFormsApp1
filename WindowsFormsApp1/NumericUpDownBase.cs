using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class NumericUpDownBase
    {
        private readonly NumericUpDown NumericUpDown;

        public int Maximum { get; internal set; }
        public int Minimum { get; internal set; }
    }
}
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private int _countSeconds = 0;
        private object chart;
        private object numericUpDown;

        private void Form_Load(object sender, EventArgs e)
        {
            Form_Load(sender, e);
        }

        private void Form_Load(object sender, EventArgs e, NumericUpDown numericUpDown)
        {
            Form_Load(sender, e, numericUpDown);
        }

        
        
        public class NumericUpDown : NumericUpDownBase
        {
            private object sender;
            private readonly object EventArgs;

             private NumericUpDown numericUpDown;
        }

        private void Form_Load(object sender, EventArgs e, NumericUpDown numericUpDown, NumericUpDown)
        {
            timer1.Enabled = true;
            numericUpDown.Maximum = 500;
            numericUpDown.Minimum = 0;

            chart1.ChartAreas[0].AxisY.Maximum = 450;
            chart1.ChartAreas[0].AxisY.Minimum = -5;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 5;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            double ranTemp = random.Next(0, 41);
            label1.Text = ranTemp.ToString();
            

            DateTime timeNow = DateTime.Now;
            int value = Convert.ToInt32(numericUpDown);

            chart1.Series[0].Points.AddXY(timeNow, value);
            chart1.Series[1].Points.AddXY(timeNow, ranTemp);

            _countSeconds++;

            if(_countSeconds == 60)
            {
                _countSeconds = 0;
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();

                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                chart1.ChartAreas[0].AxisX.Interval = 5;
            }

        }

    }
}

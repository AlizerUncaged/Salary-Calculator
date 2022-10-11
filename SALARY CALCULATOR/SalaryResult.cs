using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SALARY_CALCULATOR
{
    public partial class SalaryResult : Form
    {
        private readonly OutputModel outputModel;

        public SalaryResult(OutputModel outputModel)
        {
            InitializeComponent();
            this.outputModel = outputModel;
        }

        private void SalaryResult_Load(object sender, EventArgs e)
        {
            label1.Text = $"Name: {outputModel.Name}{Environment.NewLine}" +
                $"Rate per Hour: {outputModel.RatePerHour}{Environment.NewLine}" +
                $"Gross Pay: {outputModel.GrossPay}{Environment.NewLine}" +
                $"Deductions: {outputModel.Deductions}{Environment.NewLine}" +
                $"Net Pay: {outputModel.NetPay}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

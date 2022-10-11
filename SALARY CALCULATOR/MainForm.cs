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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Compute(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var position = positioncb.Text;
            var hrsWorked = double.Parse(textBox2.Text);
            var hrsOvertime = double.Parse(textBox3.Text);
            var moreDeductions = double.Parse(textBox4.Text);
            var ratePerHour = position == "Employee" ? 250 : position == "Manager" ? 500 : 750;

            bool isTaxable = checkBox1.Checked,
                sss = checkBox2.Checked,
                pagibig = checkBox3.Checked,
                philhealth = checkBox4.Checked;

            if (sss) moreDeductions += 300;
            if (pagibig) moreDeductions += 300;
            if (philhealth) moreDeductions += 300;

            var nonDeductedGrossPay = (hrsWorked * ratePerHour) + (hrsOvertime * (ratePerHour * 1.3d));
            var tax = 0.12 * nonDeductedGrossPay;
            var grosspay = nonDeductedGrossPay;

            if (isTaxable) moreDeductions += tax;

            var output = new OutputModel
            {
                Name = name,
                RatePerHour = $"{ratePerHour}",
                GrossPay = $"{nonDeductedGrossPay}",
                Deductions = $"{moreDeductions}",
                NetPay = $"{grosspay - moreDeductions}"
            };

            new SalaryResult(output).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var i in GetAll(this, typeof(TextBox)))
            {
                i.Text = String.Empty;
            }
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
    }
}
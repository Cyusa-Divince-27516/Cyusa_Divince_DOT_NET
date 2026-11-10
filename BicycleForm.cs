using System;
using System.Drawing;
using System.Windows.Forms;

namespace MushroomBicycleApp
{
    public class BicycleForm : Form
    {
        private NumericUpDown nudStart, nudEnd;
        private TextBox txtTotal;

        public BicycleForm()
        {
            Text = "Bicycle Rental";
            ClientSize = new Size(380, 330);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var title = new Label { Text = "BICYCLE RENTAL", Font = new Font("Segoe UI", 16, FontStyle.Bold), AutoSize = true, Location = new Point(85, 15) };

            var lblStart = new Label { Text = "Starting time (0 - 23):", AutoSize = true, Location = new Point(25, 78) };
            nudStart = new NumericUpDown { Location = new Point(220, 75), Width = 120, Minimum = 0, Maximum = 23 };

            var lblEnd = new Label { Text = "Ending time (1 - 24):", AutoSize = true, Location = new Point(25, 118) };
            nudEnd = new NumericUpDown { Location = new Point(220, 115), Width = 120, Minimum = 1, Maximum = 24, Value = 1 };

            var btnCalc = new Button { Text = "Calculate", Location = new Point(25, 160), Size = new Size(315, 35) };
            btnCalc.Click += BtnCalc_Click;

            var lblTotal = new Label { Text = "Total (RWF):", AutoSize = true, Location = new Point(25, 221) };
            txtTotal = new TextBox { Location = new Point(140, 218), Width = 200, ReadOnly = true };

            var btnLogout = new Button { Text = "Logout", Location = new Point(25, 270), Size = new Size(315, 35) };
            btnLogout.Click += (s, e) =>
            {
                LoginForm.Instance?.ShowAgain();
                Close();
            };

            Controls.AddRange(new Control[] { title, lblStart, nudStart, lblEnd, nudEnd, btnCalc, lblTotal, txtTotal, btnLogout });
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            int startTime = (int)nudStart.Value;
            int endTime = (int)nudEnd.Value;

            if (endTime <= startTime)
            {
                MessageBox.Show("Ending time must be between 1 and 24 and greater than the starting time.",
                    "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotal.Clear();
                return;
            }

            int total = 0;
            for (int hour = startTime; hour < endTime; hour++)
            {
                int rate;
                if (hour >= 0 && hour < 7) rate = 500;
                else if (hour >= 7 && hour < 14) rate = 1000;
                else if (hour >= 14 && hour < 19) rate = 1500;
                else if (hour >= 19 && hour < 21) rate = 1000;
                else rate = 500;

                total += rate;
            }

            txtTotal.Text = total + " RWF";
        }
    }
}
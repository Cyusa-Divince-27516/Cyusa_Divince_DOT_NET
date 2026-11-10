using System;
using System.Drawing;
using System.Windows.Forms;

namespace MushroomBicycleApp
{
    public partial class ChooseForm : Form
    {
        public ChooseForm()
        {
            Text = "Choose an activity";
            ClientSize = new Size(360, 220);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var title = new Label
            {
                Text = "Choose an activity",
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(95, 25)
            };
            var btnBicycle = new Button { Text = "Bicycle rental", Location = new Point(40, 85), Size = new Size(125, 40) };
            var btnMushroom = new Button { Text = "Mushroom identification", Location = new Point(195, 85), Size = new Size(125, 40) };
            btnBicycle.Click += btnBicycle_Click;
            btnMushroom.Click += btnMushroom_Click;
            Controls.AddRange(new Control[] { title, btnBicycle, btnMushroom });
        }

        private void btnBicycle_Click(object sender, EventArgs e)
        {
            new BicycleForm().Show();
            Close();
        }

        private void btnMushroom_Click(object sender, EventArgs e)
        {
            new MushroomForm().Show();
            Close();
        }

    }
}
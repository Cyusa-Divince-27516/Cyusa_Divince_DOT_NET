using System;
using System.Drawing;
using System.Windows.Forms;

namespace MushroomBicycleApp
{
    public class MushroomForm : Form
    {
        private Label lblQuestion;
        private string current = "ring";

        public MushroomForm()
        {
            Text = "Mushroom Identification";
            ClientSize = new Size(420, 280);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            var title = new Label { Text = "MUSHROOM IDENTIFICATION", Font = new Font("Segoe UI", 14, FontStyle.Bold), AutoSize = true, Location = new Point(45, 15) };
            lblQuestion = new Label { Location = new Point(30, 70), Size = new Size(360, 50), TextAlign = ContentAlignment.MiddleCenter };

            var btnYes = new Button { Text = "Yes", Location = new Point(80, 130), Size = new Size(110, 38) };
            var btnNo = new Button { Text = "No", Location = new Point(230, 130), Size = new Size(110, 38) };
            btnYes.Click += (s, e) => Answer(true);
            btnNo.Click += (s, e) => Answer(false);

            var btnRestart = new Button { Text = "Restart", Location = new Point(30, 195), Size = new Size(170, 35) };
            btnRestart.Click += (s, e) => { current = "ring"; ShowQuestion(); };

            var btnLogout = new Button { Text = "Logout", Location = new Point(220, 195), Size = new Size(170, 35) };
            btnLogout.Click += (s, e) =>
            {
                LoginForm.Instance?.ShowAgain();
                Close();
            };

            Controls.AddRange(new Control[] { title, lblQuestion, btnYes, btnNo, btnRestart, btnLogout });

            ShowQuestion();
        }

        private void ShowQuestion()
        {
            lblQuestion.Text = current switch
            {
                "ring" => "Does your mushroom have a ring?",
                "forest" => "Does your mushroom grow in a forest?",
                "convexA" => "Does your mushroom have a convex cup?",
                "gills" => "Does your mushroom have gills?",
                "convexB" => "Does your mushroom have a convex cup?",
                _ => ""
            };
        }

        private void Answer(bool yes)
        {
            string next = null;
            string result = null;

            switch (current)
            {
                case "ring":
                    next = yes ? "forest" : "gills";
                    break;
                case "forest":
                    if (yes) result = "Amanite tue-mouche"; else next = "convexA";
                    break;
                case "convexA":
                    result = yes ? "Agaric Jaunissant" : "Coprin chevelu";
                    break;
                case "gills":
                    if (!yes) result = "Cepe de Bordeaux"; else next = "convexB";
                    break;
                case "convexB":
                    result = yes ? "Pied bleu" : "Girolle";
                    break;
            }

            if (result != null)
            {
                MessageBox.Show("Your mushroom is: " + result, "Result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                current = "ring";
            }
            else
            {
                current = next;
            }

            ShowQuestion();
        }
    }
}
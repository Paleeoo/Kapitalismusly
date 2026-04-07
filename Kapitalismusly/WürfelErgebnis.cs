using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    public partial class WürfelErgebnis : Form
    {
        private int _ergebnis;

        private WürfelErgebnis(Bitmap w1, Bitmap w2)
        {
            InitializeComponent();

            this.Size = new Size(300, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Dein würfelergebnis:";
            label.Size = new Size(200, 25);
            label.Font = new Font("Arial", 15);
            label.Location = new Point(50, 10);
            PictureBox p1 = new PictureBox();
            p1.Size = new Size(100, 100);
            p1.Image = w1;
            p1.Location = new Point(25, 50);
            PictureBox p2 = new PictureBox();
            p2.Size = new Size(100, 100);
            p2.Image = w2;
            p2.Location = new Point(175, 50);
            Button b = new Button();
            b.Text = "OK";
            b.Click += (sendere, args) => this.Close();
            b.Location = new Point(150 - b.Width / 2, 170);
            this.Controls.Add(label);
            this.Controls.Add(p1);
            this.Controls.Add(p2);
            this.Controls.Add(b);
        }
            

        private void WürfelErgebnis_Load(object sender, EventArgs e)
        {
            
            
        }

        private static Bitmap GibWürfelZahl(int i)
        {
            switch (i)
            {
                case 1: return new Bitmap(Image.FromFile("würfel1.png"), 100, 100);

                case 2: return new Bitmap(Image.FromFile("würfel2.png"), 100, 100);

                case 3: return new Bitmap(Image.FromFile("würfel3.png"), 100, 100);

                case 4: return new Bitmap(Image.FromFile("würfel4.png"), 100, 100);

                case 5: return new Bitmap(Image.FromFile("würfel5.png"), 100, 100);

                case 6: return new Bitmap(Image.FromFile("würfel6.png"), 100, 100);

                default: MessageBox.Show("Ungültigen Wert Übergeben"); return null;
            }
        }

        public static int NewErgebnis(int würfel1, int würfel2)
        {
            Bitmap w1 = GibWürfelZahl(würfel1);
            Bitmap w2 = GibWürfelZahl(würfel2);

            WürfelErgebnis w = new WürfelErgebnis(w1, w2);
            w.ShowDialog();
            return w._ergebnis;

        }
    }
}

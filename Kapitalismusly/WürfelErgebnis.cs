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

        private WürfelErgebnis()
        {
            InitializeComponent();

            this.Size = new Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Dein würfelergebnis:";
            label.Size = new Size(200, 25);
            label.Font = new Font("Arial", 15);
            label.Location = new Point(50, 10);
            PictureBox p1 = new PictureBox();
            p1.Size = new Size(100, 100);
            //p1.Image = w1;
            p1.Location = new Point(25, 50);
            PictureBox p2 = new PictureBox();
            p2.Size = new Size(100, 100);
            //p2.Image = w2;
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

        public static int ADDD()
        {
            

            WürfelErgebnis w = new WürfelErgebnis();
            w.ShowDialog();
            return w._ergebnis;

        }
    }
}

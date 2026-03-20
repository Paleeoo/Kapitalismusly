using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    public partial class CreatePlayer : Form
    {

         static List<Color> Figurs = new List<Color>();

        private Color playercolor;
        private List<MultiPictureBoxBox> Boxen = new List<MultiPictureBoxBox>();

        public CreatePlayer()
        {
            InitializeComponent();
            CreateFigures();

            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 10);
            textBox1.Location = new Point(this.Width / 2 - textBox1.Width / 2, 48);
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, 96);
            AddFigurs(120 + 25, Figurs.Count, 0);
            button1.Location = new Point(200 - button1.Width /2, this.Height - 75);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;

        }

        private void AddFigurs(int y, int count, int figur)
        {
            if (count == 0)
                return;

            this.Size = new Size(this.Width, this.Height + 125);

            MultiPictureBoxBox t = new MultiPictureBoxBox(Figurs[figur], this.Width / 25, y);
            t.Click += (sender, e) => ClickBox(sender, e, t);
            this.Controls.Add(t);
            Boxen.Add(t);

            if (count > 1)
            {
                MultiPictureBoxBox t2 = new MultiPictureBoxBox(Figurs[figur + 1], 150, y);
                t2.Click += (sender, e) => ClickBox(sender, e, t2);
                this.Controls.Add(t2);
                Boxen.Add(t2);
            }
                

            if (count > 2)
            {
                MultiPictureBoxBox t3 = new MultiPictureBoxBox(Figurs[figur + 2], 275, y);
                t3.Click += (sender, e) => ClickBox(sender, e, t3);
                this.Controls.Add(t3);
                Boxen.Add(t3);

                figur += 3;
                count -= 3;
                y += 125;
                AddFigurs(y, count, figur);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            if (this.textBox1.Text == "")
            { MessageBox.Show("Bitte einen Namen Angeben"); return; }

            if (playercolor == null)
            { MessageBox.Show("Bitte beine Farbe Auswählen"); return; }


            PictureBox temp = new PictureBox();
            temp.Size = new Size(30, 30);
            GameLogic.Playerlist.Add(new Player(this.textBox1.Text, new PictureBox()));
            Figurs.Remove(playercolor);

            this.Close();
        }

        public void CreateFigures()
        {
            if (Figurs.Count != 0)
                return;

            Figurs.Add(Color.Red);
            Figurs.Add(Color.Blue);
            Figurs.Add(Color.Green);
            Figurs.Add(Color.Yellow);
            Figurs.Add(Color.Brown);
            Figurs.Add(Color.Black);
            Figurs.Add(Color.Purple);
        }

        public  void ClickBox(object sender, EventArgs e, MultiPictureBoxBox m)
        {
            playercolor = m.Color;
            Boxen.ForEach(x => x.BorderStyle = BorderStyle.None);

            m.BorderStyle = BorderStyle.Fixed3D;

        }
    }


    public partial class MultiPictureBoxBox : PictureBox
    {
        public readonly Color Color;

        public MultiPictureBoxBox(Color color, int y, int x)
        {
            Size = new Size(100, 100);
            Color = color;
            BackColor = color;
            Location = new Point(y,x);
        }

        
    }
}



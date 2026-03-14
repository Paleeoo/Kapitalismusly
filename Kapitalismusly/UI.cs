using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {

            /*

            PictureBox p1 = new PictureBox();
            p1.Size = new System.Drawing.Size(30, 60);
            p1.BackColor = Color.Purple;
            p1.Location = new Point(10, 20);
            this.Controls.Add(p1);
            players[0] = new Player("Player 1", p1);


            p1 = new PictureBox();
            p1.Size = new System.Drawing.Size(30, 30);
            p1.BackColor = Color.Green;
            p1.Location = new Point(10, 60);
            this.Controls.Add(p1);
            players[1] = new Player("Player 1", p1);


            panel1.Controls.Add(players[0].picturebox);
            MessageBox.Show(".");
            this.Controls.Add(players[0].picturebox);*/

            StreetTest();

            
        }

        private void StreetTest()
        {
            GameLogic.GameField.Add (new Street("street1", panel2, true));
            
        }

        public void Interface()
        {
            //Label Money = GameLogic.PlayeronZug.Money;  einfügen

            Button Würefel = new Button();
            this.Controls.Add(Würefel);





        }

        internal static void StreedAuktion()
        {
            Timer t = new Timer
        }

        public void NewRound()
        {

        }

        public void ActivateButtonNext()
        {
            buttonNext.Visible = true;
            buttonNext.Enabled = true;
        }
        public void ActivateButtonRoll()
        {
            buttonRoll.Visible = true;
            buttonRoll.Enabled = true;
        }
        

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Visible = false;
            buttonNext.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
            GameLogic.RoundEnd();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            buttonRoll.Visible = false;
            buttonRoll.Enabled = false;
            Random random = new Random();
            int würfel1 = random.Next(1, 7);
            Bitmap w1 = GibWürfelZahl(würfel1);
            int würfel2 = random.Next(1, 7);
            Bitmap w2 = GibWürfelZahl(würfel2);

            Form temp = new Form();
            temp.Size = new Size(300, 200);
            temp.FormBorderStyle = FormBorderStyle.FixedSingle;
            temp.ControlBox = false;
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Dein würfelergebnis:";
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
            b.Click += (senderb, args) => temp.Close();
            b.Location = new Point(150 - b.Width / 2, 170);
            temp.Controls.Add(label);
            temp.Controls.Add(p1);
            temp.Controls.Add(p2);
            temp.Controls.Add(b);
            Application.Run(temp);

            GameLogic.Round(random.Next(1, 7), random.Next(1, 7));
        }

        private Bitmap GibWürfelZahl(int i)
        {
            if (i == 1) return new Bitmap(Image.FromFile("würfel1.png"), 100, 100);
            if (i == 2) return new Bitmap(Image.FromFile("würfel2.png"), 100, 100);
            if (i == 3) return new Bitmap(Image.FromFile("würfel3.png"), 100, 100);
            if (i == 4) return new Bitmap(Image.FromFile("würfel4.png"), 100, 100);
            if (i == 5) return new Bitmap(Image.FromFile("würfel5.png"), 100, 100);
            return new Bitmap(Image.FromFile("würfel6.png"), 100, 100);
        }

        
    }
}

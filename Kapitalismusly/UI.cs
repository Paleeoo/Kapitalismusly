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

            Application.Run(new WürfelErgebnis(w1, w2));

            GameLogic.Round(würfel1, würfel2);
        }

        private Bitmap GibWürfelZahl(int i)
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
    }
}

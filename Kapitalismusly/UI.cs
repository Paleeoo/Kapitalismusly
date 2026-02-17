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

        
    }
}

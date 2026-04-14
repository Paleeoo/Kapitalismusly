using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            GameLogic.GameField.Add(new Start(panel1));
            List<Street> temp1 = new List<Street>();
            temp1.Add(new StreetWithHous("straße 1.1", 60, temp1, 50, 2, 10, 30, 90, 160, 250, panel2, label1, true));
            GameLogic.GameField.Add(temp1[0]);
            GameLogic.GameField.Add(new Gemeinschaftsfeld(panel3));
            temp1.Add(new StreetWithHous("straße 1.2", 60, temp1, 50, 4, 20, 60, 180, 320, 450, panel4, label2, true));
            GameLogic.GameField.Add(temp1[1]);
            GameLogic.GameField.Add(new BadField(panel5, 200));
            List<Street> bahnhöfe = new List<Street>();
            bahnhöfe.Add(new TrainStation("Bahnhof1", panel6, true, bahnhöfe));
            GameLogic.GameField.Add(bahnhöfe[0]);
            bahnhöfe.Add(new TrainStation("Bahnhof2", panel16, true, bahnhöfe));
            bahnhöfe.Add(new TrainStation("Bahnhof3", panel26, false, bahnhöfe));
            bahnhöfe.Add(new TrainStation("Bahnhof4", panel36, false, bahnhöfe));
            List<Street> temp2 = new List<Street>();
            temp2.Add(new StreetWithHous("straße2.1", 100, temp2, 50, 6, 30, 90, 270, 400, 550, panel7, label3, true));
            GameLogic.GameField.Add(temp2[0]);
            GameLogic.GameField.Add(new Ereignisfeld(panel8));
            temp2.Add(new StreetWithHous("straße2.2", 100, temp2, 50, 6, 30, 90, 270, 400, 550, panel9, label4, true));
            GameLogic.GameField.Add(temp2[1]);
            temp2.Add(new StreetWithHous("straße2.3", 120, temp2, 50, 8, 40, 100, 300, 450, 600, panel10, label5, true));
            GameLogic.GameField.Add(temp2[2]);
            GameLogic.GameField.Add(new Jail(panel11, panel111));
            List<Street> temp3 = new List<Street>();
            temp3.Add(new StreetWithHous("straße3.1", 140, temp3, 100, 10, 50, 150, 450, 625, 750, panel12, label6, true));
            GameLogic.GameField.Add(temp3[0]);
            List<Street> Werke = new List<Street>();
            Werke.Add(new BasicServices("strom", 150, panel13, true, Werke));
            GameLogic.GameField.Add(Werke[0]);
            temp3.Add(new StreetWithHous("straße3.2", 140, temp3, 100, 10, 50, 150, 450, 625, 750, panel14, label7, true));
            GameLogic.GameField.Add(temp3[1]);
            temp3.Add(new StreetWithHous("straße3.3", 160, temp3, 100, 12, 60, 180, 500, 700, 900, panel16, label8, true));
            GameLogic.GameField.Add(temp3[2]);
            GameLogic.GameField.Add(bahnhöfe[1]);
            List<Street> temp4 = new List<Street>();
            temp4.Add(new StreetWithHous("straße4.1", 180, temp4, 100, 14, 70, 200, 550, 750, 950, panel17, label9, true));
            GameLogic.GameField.Add(temp4[0]);
            GameLogic.GameField.Add(new Gemeinschaftsfeld(panel18));
            temp4.Add(new StreetWithHous("straße4.2", 180, temp4, 100, 14, 70, 200, 550, 750, 950, panel19, label10, true));
            GameLogic.GameField.Add(temp4[1]);
            temp4.Add(new StreetWithHous("straße4.3", 200, temp4, 100, 16, 80, 220, 600, 800, 1000, panel20, label11, true));
            GameLogic.GameField.Add(temp4[2]);
            GameLogic.GameField.Add(new FreeParking(panel21));
            List<Street> temp5 = new List<Street>();
            temp5.Add(new StreetWithHous("straße5.1", 220, temp5, 150, 18, 90, 250, 700, 875, 1050, panel22, label12, false));
            GameLogic.GameField.Add(temp5[0]);
            GameLogic.GameField.Add(new Ereignisfeld(panel23));
            temp5.Add(new StreetWithHous("straße5.2", 220, temp5, 150, 18, 90, 250, 700, 875, 1050, panel24, label13, false));
            GameLogic.GameField.Add(temp5[1]);
            temp5.Add(new StreetWithHous("straße5.3", 240, temp5, 150, 20, 100, 300, 750, 925, 1100, panel25, label14, false));
            GameLogic.GameField.Add(temp5[2]);
            GameLogic.GameField.Add(bahnhöfe[2]);
            List<Street> temp6 = new List<Street>();
            temp6.Add(new StreetWithHous("straße6.1", 260, temp6, 150, 22, 110, 330, 800, 975, 1150, panel27, label15, false));
            GameLogic.GameField.Add(temp6[0]);
            temp6.Add(new StreetWithHous("straße6.2", 260, temp6, 150, 22, 110, 330, 800, 975, 1150, panel28, label16, false));
            GameLogic.GameField.Add(temp6[1]);
            Werke.Add(new BasicServices("Wasserwerk", 150, panel29, false, Werke));
            GameLogic.GameField.Add(Werke[1]);
            temp6.Add(new StreetWithHous("straße6.3", 280, temp6, 150, 24, 120, 360, 850, 1025, 1200, panel30, label17, false));
            GameLogic.GameField.Add(temp6[1]);
            GameLogic.GameField.Add(new Policeman(panel31));
            List<Street> temp7 = new List<Street>();
            temp7.Add(new StreetWithHous("straße7.1", 300, temp7, 200, 26, 130, 390, 900, 1100, 1275, panel32, label18, false));
            GameLogic.GameField.Add(temp7[0]);
            temp7.Add(new StreetWithHous("straße7.2", 300, temp7, 200, 26, 130, 390, 900, 1100, 1275, panel33, label19, false));
            GameLogic.GameField.Add(temp7[1]);
            GameLogic.GameField.Add(new Gemeinschaftsfeld(panel34));
            temp7.Add(new StreetWithHous("straße7.3", 320, temp7, 200, 28, 150, 450, 1000, 1200, 1400, panel35, label20, false));
            GameLogic.GameField.Add(temp7[2]);
            GameLogic.GameField.Add(bahnhöfe[3]);
            GameLogic.GameField.Add(new Ereignisfeld(panel37));
            List<Street> temp8 = new List<Street>();
            temp8.Add(new StreetWithHous("straße8.1", 350, temp8, 200, 35, 175, 500, 1100, 1300, 1500, panel38, label21, false));
            GameLogic.GameField.Add(temp8[0]);
            GameLogic.GameField.Add(new BadField(panel39, 100));
            temp8.Add(new StreetWithHous("straße8.2", 400, temp8, 200, 50, 200, 600, 1400, 1700, 2000, panel38, label21, false));
            GameLogic.GameField.Add(temp8[1]);


            UpdateInterface();
            ActivateButtonRoll();


        }

        private void UpdateInterface()
        {
            labelPlayer.Text = GameLogic.PlayeronZug.Name + " ist am Zug";
            labelMoney.Text = GameLogic.PlayeronZug.Money.ToString() + "€";
        }

        private void NewRound()
        {
            GameLogic.RoundEnd();
            UpdateInterface();
            ActivateButtonRoll();
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
            NewRound();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            buttonRoll.Visible = false;
            buttonRoll.Enabled = false;
            Random random = new Random();
            int würfel1 = random.Next(1, 7);
            int würfel2 = random.Next(1, 7);
            WürfelErgebnis.NewErgebnis(würfel1, würfel2);

            GameLogic.Round(würfel1, würfel2);
        }
        
    }
}

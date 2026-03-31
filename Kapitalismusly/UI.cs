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

           
        }

        private void NewTrainStation(string name1, int price1, Panel panel1, string name2, int price2, Panel panel2, string name3, int price3, Panel panel3, string name4, int price4, Panel panel4)
        {
            List<Street> temp = new List<Street>();

            temp.Add(new TrainStation(name1, price1, panel1, true, temp));
            temp.Add(new TrainStation(name2, price2, panel2, true, temp));
            temp.Add(new TrainStation(name3, price3, panel3, true, temp));
            temp.Add(new TrainStation(name4, price4, panel4, true, temp));

        }

        private void NewStreetWithHous(string Name1, int Price1, (int, int, int, int, int, int, int) all1, Panel StreetPanel1, Panel HousPanel1, string Name2, int Price2, (int, int, int, int, int, int, int) all2, Panel StreetPanel2, Panel HousPanel2, bool richtung)
        {
            List<Street> temp = new List<Street>();

            temp.Add(new StreetWithHous(Name1, Price1, temp, all1.Item1, all1.Item2, all1.Item3, all1.Item4, all1.Item5, all1.Item6, all1.Item7, StreetPanel1, HousPanel1, richtung));
            temp.Add(new StreetWithHous(Name2, Price2, temp, all2.Item1, all2.Item2, all2.Item3, all2.Item4, all2.Item5, all2.Item6, all2.Item7, StreetPanel2, HousPanel2, richtung));
        }

        private void NewStreetWithHous(string Name1, int Price1, (int,int,int,int,int,int,int) all1, Panel StreetPanel1, Panel HousPanel1, string Name2, int Price2, (int, int, int, int, int, int, int) all2, Panel StreetPanel2, Panel HousPanel2, string Name3, int Price3, (int, int, int, int, int, int, int) all3, Panel StreetPanel3, Panel HousPanel3, bool richtung)
        {
            List<Street> temp = new List<Street>();

            temp.Add(new StreetWithHous(Name1, Price1, temp, all1.Item1, all1.Item2, all1.Item3, all1.Item4, all1.Item5, all1.Item6, all1.Item7, StreetPanel1, HousPanel1, richtung));
            temp.Add(new StreetWithHous(Name2, Price2, temp, all2.Item1, all2.Item2, all2.Item3, all2.Item4, all2.Item5, all2.Item6, all2.Item7, StreetPanel2, HousPanel2, richtung));
            temp.Add(new StreetWithHous(Name2, Price3, temp, all3.Item1, all3.Item2, all3.Item3, all3.Item4, all3.Item5, all3.Item6, all3.Item7, StreetPanel3, HousPanel3, richtung));
        }

        public void Interface()
        {
            //Label Money = GameLogic.PlayeronZug.Money;  einfügen

            Button Würefel = new Button();
            this.Controls.Add(Würefel);


            MessageBox.Show("");


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
            
            MessageBox.Show("");

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

            WürfelErgebnis.NewErgebnis(w1, w2);
            

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

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

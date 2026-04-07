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
    public partial class Spielerreinenfolge : Form
    {
        private (Player, int)[] temparry = new (Player, int)[GameLogic.Playerlist.Count];
        private Player aktuelplayer;

        private Spielerreinenfolge()
        {
            InitializeComponent();
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 9);
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, 60);
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, 200);
        }

        public void Start()
        {
            foreach (var item in GameLogic.Playerlist)
            {
                aktuelplayer = item;
                label2.Text = aktuelplayer.Name + " du bist dran.\nBitte einmal würfeln.";
                this.ShowDialog();
            }
            label1.Text = null;

            while (true)
            {
                Sort();

                bool j = true;
                (Player, int) temp = (null, 0);

                for (int i = 0; i < temparry.Length; i++)
                {
                    if (i == 0)
                        temp = temparry[i];
                    else
                    {
                        if (temparry[i].Item2 == temp.Item2)
                        {
                            MessageBox.Show("Zwei leite aben das selbe ergebnis gewürfelt.\nWir müssen das leider nochmal nwiederholen...");
                            j = false;
                            aktuelplayer = temparry[i - 1].Item1;
                            temparry[i - 1] = (null, 0);
                            label2.Text = aktuelplayer.Name + " du bist dran.\nBitte einmal würfeln.";
                            this.ShowDialog();
                            aktuelplayer = temparry[i].Item1;
                            temparry[i - 1] = (null, 0);
                            label2.Text = aktuelplayer.Name + " du bist dran.\nBitte einmal würfeln.";
                            this.ShowDialog();
                            break;
                        }
                        
                        temp = temparry[i];
                    }
                }
                if (j)
                    break;
            }

            GameLogic.Playerlist = new List<Player>();
            foreach (var item in temparry)
            {
                GameLogic.Playerlist.Add(item.Item1);
            }
            GameLogic.PlayeronZug = GameLogic.Playerlist[0];
        }

        private void Sort()
        {
            while (true)
            {
                bool j = true;
                (Player, int) temp = (null, 0);

                for (int i = 0; i < temparry.Length; i++)
                {
                    if (i == 0)
                        temp = temparry[i];
                    else
                    {
                        if (temparry[i].Item2 > temp.Item2)
                        {
                            temparry[i - 1] = temparry[i];
                            temparry[i] = temp;
                            j = false;
                        }
                    }
                }
                if (j)
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int würfel1 = random.Next(1, 7);
            int würfel2 = random.Next(1, 7);
            WürfelErgebnis.NewErgebnis(würfel1, würfel2);

            for (int i = 0; i < temparry.Length; i++)
            {
                if (temparry[i].Item1 == null)
                {
                    temparry[i] = (aktuelplayer, würfel1 + würfel2);
                    break;
                }
            }
            this.Close();
        }


        public static void SortPlayer()
        {
            if (GameLogic.NoMorePlayer)
                return;

            Spielerreinenfolge temp = new Spielerreinenfolge();
            temp.Start();


        }
    }
}

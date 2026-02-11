using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Player
    {
        public readonly string Name;
        public readonly Bitmap Figur;
        private List<Street> _streets = new List<Street>();
        public PictureBox picturebox;
        private int _money;
        public Field OnField;

        public int Money
        {
            get { return _money; }
            set { return; }
        }

        public Player(string name, int money, PictureBox p, Bitmap fiegur)
        {


        }

        public Player(string name, PictureBox p)
        {
            Name = name;
            picturebox = p;
        }

        public void MoneyTransfer(Player player, int i)
        {
            if (i <= Money)
            {
                _money -= i;
                player.MoneyTransfer(i);
            }
            else   
            {
                if (i > Money + Eigentumswerte())
                {
                    SellAllStreets();
                    player.MoneyTransfer(Money);
                    _money = 0;
                    GameOver();
                }
                else
                {
                    //verkauf um differenz zu decken
                }
            }

        }

        public void AddStreed(Street street) { _streets.Add(street); }
 
        public void MoneyTransfer(int i)
        {
            _money += i;
            if (Money < 0) Pleiteabwenden();
        }



        private void Pleiteabwenden()
        {
            if (Money + Eigentumswerte() < 0)
            {
                SellAllStreets();
                GameOver();
            }
            else
            {
                //Verkaufhinzufügen
            }


        }

        private int Eigentumswerte()
        {
            int i = 0;
            foreach (var item in _streets)
            {
                i += item.Wert;
            }
            return i / 2;
        }

        public void SellAllStreets()
        {
            foreach (var item in _streets)
            {
                _money += item.Wert / 2;
                item.BackToBank(); // hinzufügen
            }
        }

        private void GameOver()
        {
            OnField.LeaveField(this);
            GameLogic.Playerlist.Remove(this);
        }
    }
}

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

        public void MoneyTransfer(int i)
        {
            
        }

        public void RemoveMoney(int i)
        {
            _money -= i;

            if (_money < 0) Pleiteabwenden();
        }


        private void Pleiteabwenden()
        {
            if (_streets.Count == 0) GameOver();

            int i = 0;
            foreach (var item in _streets)
            {
                i += item.Wert;
            }

            if (_money + (i/2) <= 0) GameOver();

            // starte auswahl zu verkauf

        }

        private void GameOver()
        {
            OnField.LeaveField(this);
            GameLogic.Playerlist.Remove(this);
        }
    }
}

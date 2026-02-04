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

            if (_money < 0)///
        }


        private void Pleiteabwenden()
        {

        }
    }
}

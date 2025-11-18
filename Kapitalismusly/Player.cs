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
        private int money;

        public int Money
        {
            get { return money; }
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
    }
}

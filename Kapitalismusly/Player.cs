using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapitalismusly
{
    internal class Player
    {
        public readonly string Name;
        public readonly Bitmap Figur;
        private List<Street> _streets = new List<Street>();
        private int money;

        public int Money
        {
            get
            {
                return money;
            }
            set { }
        }

        public Player(string name, int money, Bitmap fiegur)
        {


        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Street : Field
    {
        public readonly Bitmap Card;
        public readonly int Price;
        public Player Owner;
        protected bool _richtung; 

        public Street(string name, Panel panel, bool richtung)
        {
            _name = name;
            _place = panel;
        }


        public void S()
        {
            
        }


       


    }
}

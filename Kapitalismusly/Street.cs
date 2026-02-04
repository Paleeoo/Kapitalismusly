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
        public readonly int Price;  //get und set fehle b.z. berechner
        public Player Owner; 

        public Street(string name, Panel panel, bool richtung)
        {
            _name = name;
            _place = panel;
            _direction = richtung;
        }

        public void StepOn()
        {
            if (Owner == null)
            {

            }
        }

        protected void Buy(Player player)
        {
            player.Money
        }

        protected void Auction()
        {

        }


        public void S()
        {
            
        }


       


    }
}

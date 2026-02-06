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
        public int Wert;
        public Player Owner; 

        public Street(string name,int preis, Panel panel, bool richtung)
        {
            _name = name;
            Price = preis;
            _place = panel;
            _direction = richtung;
        }

        public Street(string name, Panel panel, bool richtung) // einfach zum test
        {
            _name = name;
            _place = panel;
            _direction = richtung;
        }

        public void StepOn(Player player)
        {
            if (Owner == null)
            {
                if (player.Money >= Price)
                {
                    //abfrage obkaufen
                }
                else
                {
                    MessageBox.Show("Du Geringverdiener kannst dir die straße nicht leisten... \n Sie wird versteigert!");
                    //versteigerung der straße
                }
            }
        }

        protected void Buy(Player player)
        {
            player.RemoveMoney(Price);
        }

        protected void Auction()
        {

        }


        public void S()
        {
            
        }


       


    }
}

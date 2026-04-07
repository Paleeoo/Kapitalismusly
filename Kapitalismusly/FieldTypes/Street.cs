using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Kapitalismusly
{
    internal class Street : Field
    {
        public int HousPrice;
        public readonly Bitmap Card;
        public readonly int Price;  
        protected int wert;
        protected Player _owner;
        public readonly List<Street> streetfamaly;

        public Player Owner
        {
            get { return _owner; }
            set { return; }
        }
 
        public int Wert
        {
            get { return wert; }
            set { return; }
        }

        public int Houscount
        {
            get { return 0; }
            set { return; }
        }

        public Street(string name,int preis, Panel panel, bool richtung, List<Street> list)
        {
            _name = name;
            Price = preis;
            wert = preis / 2;
            _place = panel;
            streetfamaly = list;
        }

        public bool StreetFammelyQuery()
        {
            bool temp = true;
            foreach (var item in streetfamaly)
            {
                if (item.Owner != Owner)
                    temp = false;
            }
            return temp;
        }



        protected void Kaufabfrage(Player player)
        {
            if (player.Money >= Price)
            {
                int i = 0;
                foreach (var item in streetfamaly)
                {
                    if (item.Owner == player) 
                        i++;
                }
                string count;
                if (i == 0)
                    count = "keine";
                else 
                    count = i.ToString();

                var result = MessageBox.Show("Willst du die Straße kaufen?\nDu besitzt " + count + " der Schwesterstraßen.", "Straße kaufen?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    Buy(player,Price);
                else
                    SAuction();
            }
            else
            {
                MessageBox.Show("Du Geringverdiener kannst dir die straße nicht leisten...\nSie wird versteigert!");
                SAuction();
            }
        }

        protected void Buy(Player player, int i)
        {
            player.MoneyTransfer(-i);
            _owner = player;
            player.AddStreed(this);
        }

        protected void SAuction()
        {
            Player temp;
            int wert;
            Auction.StartNewAuction(out temp, out wert, Name);

            if (temp == null)
                return;

            Buy(temp, wert);

        }

        public void BackToBank()
        {
            _owner = null;
        }

        public void BuyHous()
        {
            //macht nichts
        }
    }
}

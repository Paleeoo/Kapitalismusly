using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class BasicServices : Street
    {
        public BasicServices (string name, int preis, Panel panel, bool richtung, List<Street> list) : base(name, preis, panel, richtung, list) {}

        public new void StepOn(Player player, int i)
        {
            Positioning(player);
            if (Owner == null) Kaufabfrage(player);

            else
            {
                if (player == _owner) return;
                else
                {
                    bool dummername = true;

                    foreach (var item in streetfamaly)
                    {
                        if (item != this && item.Owner == _owner) 
                            dummername = false;
                    }

                    if (dummername) i *= 10;
                    else i *= 4;

                    player.MoneyTransfer(_owner, i);
                }
            }
        }
    }
}

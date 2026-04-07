using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class TrainStation : Street
    {

        public TrainStation(string name, Panel panel, bool richtung, List<Street> list) : base(name, 200, panel, richtung, list) { }

        public new void StepOn(Player player)
        {
            Positioning(player);
            if (Owner == null) Kaufabfrage(player);

            else
            {
                if (player == _owner) return;
                else
                {
                    int count = 0;
                    foreach (var item in streetfamaly)
                    {
                        if (item.Owner == _owner) count++;    
                    }

                    int cost = 25;
                    for (int i = 1; i < count; i++)
                    {
                        cost *= 2;
                    }
                    player.MoneyTransfer(_owner, cost);
                }
            }
        }

    }
}

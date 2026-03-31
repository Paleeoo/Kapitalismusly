using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class BadField : Field
    {
        readonly private int _minusMonney;

        public BadField(Panel panel, int wert)
        {
            _place = panel;
            _minusMonney = wert;
        }

        public new void StepOn(Player player)
        {
            Positioning(player);

            player.MoneyTransfer(_minusMonney);

        }
    }
}

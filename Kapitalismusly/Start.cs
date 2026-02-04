using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Start : Field
    {
        public Start(Panel panel)
        {
            _place = panel;
        }

        public void StepOn(Player player)  //FixMe
        {

        }

        public void StepOver(Player player, bool monney ) // kein rückwertz 
        {
            if (monney) return;
            
        }

        private void GiveMonney(Player player)
        {

        }
    }
}

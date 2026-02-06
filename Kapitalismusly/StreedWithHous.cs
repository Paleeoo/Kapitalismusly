using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class StreedWithHous : Street
    {
        private Panel _houseplace = new Panel(); 

        public StreedWithHous(string name, int preis, Panel place, Panel housplace, bool richtung) : base(name, preis,place, richtung)
        {
            //Fixme
        }


        public new void StepOn(Player player)
        {
            if (Owner == null)
            {
                Buy(player);
            }
        }

        public void BuyHous()
        {

        }


    }


}

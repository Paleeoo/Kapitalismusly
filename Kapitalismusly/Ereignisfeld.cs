using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Ereignisfeld
    {
        public void StepOn()
        {

        }
        private void Strafen()
        {

        }

        private void GoToJail()
        {
            MessageBox.Show("Du hast diene GEZ nicht gezahl... \n Geh auf den schnellsten weg in den Knast!");
        }

        private void Startsütum(Player player)
        {
            bool test = false;
            List<Street> temp = new List<Street>();
            foreach (var item in player._streets)
            {
                if (item.GetType() == typeof(StreetWithHous)) temp.Add(item);
            }

            if (temp.Count != 0)
            {
                Random random = new Random();
                Street tempstreet = temp[random.Next(temp.Count)];
                MessageBox.Show("Es ist ein Fehler aufgetreten.\n Die Zufahrt der " + tempstreet.Name + "gehört dir nicht.\n Kaufe sie für 500€. ");
                player.MoneyTransfer(-500);
            }
            else StepOn();
        }
    }
}

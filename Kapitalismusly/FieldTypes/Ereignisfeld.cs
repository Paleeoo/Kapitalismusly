using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Ereignisfeld : Field
    {
        public Ereignisfeld(Panel panel)
        {
            _place = panel;
        }


        public new void StepOn(Player player)
        {
            Positioning(player);
            Strafen(player);
        }
        private void Strafen(Player player)
        {
            Random random = new Random();

            switch (random.Next(0,3))
            {
                case 0: GoToJail();
                     return;

                case 1: BauAmtsürtum(player);
                     return;

                case 2: StererNachzahlung(player);
                    return;
            }

        }

        private void GoToJail()
        {
            MessageBox.Show("Du hast diene GEZ nicht gezahl... \n Geh auf den schnellsten weg in den Knast!");
        }

        private void StererNachzahlung(Player player)
        {
            MessageBox.Show("Du hast zu wenig steuern gezahlt!\nZahle 200€", "Steuernachzahlung");
            player.MoneyTransfer(-200);
        }

        private void BauAmtsürtum(Player player)
        {
            List<Street> temp = new List<Street>();
            foreach (var item in player.Streets)
            {
                if (item.GetType() == typeof(StreetWithHous)) 
                    temp.Add(item);
            }

            if (temp.Count != 0)
            {
                Random random = new Random();
                Street tempstreet = temp[random.Next(temp.Count)];
                MessageBox.Show("Es ist ein Fehler aufgetreten.\n Die Zufahrt der " + tempstreet.Name + "gehört dir nicht.\n Kaufe sie für 500€. ", "BauAmtsürtum");
                player.MoneyTransfer(-500);
            }
            else 
                StepOn(player);
        }
    }
}

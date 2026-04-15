using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Gemeinschaftsfeld : Field
    {
        public Gemeinschaftsfeld(Panel panel)
        {
            _place = panel;
        }

        public override void StepOn(Player player)
        {
            Positioning(player);
            Strafen(player);
        }

        private void Strafen(Player player)
        {
            Random random = new Random();

            /*
            switch (random.Next(0, 3))
            {
                case 0:
                    GoToJail();
                    return;

                case 1:
                    BauAmtsürtum(player);
                    return;

                case 2:
                    StererNachzahlung(player);
                    return;
            }
            */
        }

        private void Firma(Player player)
        {
            MessageBox.Show("Deine Firmal läuft gut!\nSchütte allen anderen spielern eine Dividente von 200€ aus;");

            foreach (var item in GameLogic.Playerlist)
            {
                if (item != player)
                    player.MoneyTransfer(item, 200);
            }
        }

        private void JailFreeCard(Player player)
        {
            bool temp = true;
            for (int i = 0; i < GameLogic.JailFreeCard.Length; i++)
            {
                if (GameLogic.JailFreeCard[i] == null)
                {
                    temp = false;
                    GameLogic.JailFreeCard[i] = player;
                }
            }

            if (temp)
                Strafen(player);
        }
    }
}

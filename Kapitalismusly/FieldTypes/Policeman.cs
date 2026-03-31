using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Policeman : Field
    {
        public Policeman(Panel panel)
        {
            _place = panel;
        }

        public new void StepOn(Player player)
        {
            MessageBox.Show("Tja. Wer die Finger hält nicht still, der wohl länger sitzen will!");
            GameLogic.GoToJail();
        }

        public new void GoOver(Player player)
        {
            _place.Controls.Add(player.picturebox);
            int timer = 300;
            int y = 91 - 30 - 15;
            int x = _place.Height - 30;

            player.picturebox.Location = new Point(y, x);
            Thread.Sleep(timer);
            x = y;
            player.picturebox.Location = new Point(y, x);
            Thread.Sleep(timer);
            y = _place.Width - 30;
            player.picturebox.Location = new Point(y, x);
        }
    }
}

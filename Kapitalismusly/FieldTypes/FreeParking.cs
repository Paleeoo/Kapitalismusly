using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class FreeParking : Field
    {
        public FreeParking(Panel panel)
        {
            _place = panel;
        }


        public new void StepOn(Player player)
        {
            Positioning(player);
        }

        public new void StepOver(Player player)      //Fixmeee timer
        {
            _place.Controls.Add(player.picturebox);

            int y = 46;
            int x = _place.Height - 91 + 15;

            player.picturebox.Location = new Point(_place.Width, x);
            player.picturebox.Location = new Point(y, x);                       //Fixmeee timer
            player.picturebox.Location = new Point(y, 0);

        }

        public new void GoBack(Player player)       //Fixmeee timer
        {
            _place.Controls.Add(player.picturebox);

            int y = 46;
            int x = _place.Height - 91 + 15;

            player.picturebox.Location = new Point(y, 0);
            player.picturebox.Location = new Point(y, x);
            player.picturebox.Location = new Point(_place.Width, x);
        }

        protected new void Positioning(Player player)
        {
            player.OnField = this;
            _playersonfield.Add(player);
            _place.Controls.Add(player.picturebox);
            Positioning();
        }

        protected new void Positioning()
        {
            bool OnePlayerOnField = true;
            if (_playersonfield.Count > 1) OnePlayerOnField = false;

            if (OnePlayerOnField)
                _playersonfield[0].picturebox.Location = new Point(_place.Width / 2 - 15, _place.Height - 40);
            else
            {
                _playersonfield[0].picturebox.Location = new Point(_place.Width / 2 - 35, _place.Height - 40);
                _playersonfield[0].picturebox.Location = new Point(_place.Width / 2 + 15, _place.Height - 40);
            }
        }
    }
}

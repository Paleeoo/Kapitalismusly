using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Kapitalismusly
{
    internal class FreeParking : Field
    {
        public FreeParking(Panel panel)
        {
            _place = panel;
        }


        public override void StepOn(Player player)
        {
            Positioning(player);
        }

        public new async void StepOver(Player player)      //Fixmeee timer
        {
            _place.Controls.Add(player.picturebox);
            int time = 300;
            int y = 46;
            int x = _place.Height - 91 + 15;

            player.picturebox.Location = new Point(_place.Width, x);
            await Task.Delay(time);
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            player.picturebox.Location = new Point(y, 0);
            await Task.Delay(time);

        }

        public new async void GoBack(Player player)       //Fixmeee timer
        {
            _place.Controls.Add(player.picturebox);
            int time = 300;

            int y = 46;
            int x = _place.Height - 91 + 15;

            player.picturebox.Location = new Point(y, 0);
            await Task.Delay(time);
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            player.picturebox.Location = new Point(_place.Width, x);
            await Task.Delay(time);
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

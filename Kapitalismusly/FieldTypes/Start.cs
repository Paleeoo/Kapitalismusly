using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Start : Field
    {
        public Start(Panel panel)
        {
            _place = panel;

            int i = GameLogic.Playerlist.Count;

            GameLogic.Playerlist[0].OnField = this;
            _playersonfield.Add(GameLogic.Playerlist[0]);
            _place.Controls.Add(GameLogic.Playerlist[0].picturebox);
            GameLogic.Playerlist[0].picturebox.Location = new Point(18, 67);

            GameLogic.Playerlist[1].OnField = this;
            _playersonfield.Add(GameLogic.Playerlist[1]);
            _place.Controls.Add(GameLogic.Playerlist[1].picturebox);
            GameLogic.Playerlist[1].picturebox.Location = new Point(67, 67);

            if (i > 2)
            {
                GameLogic.Playerlist[2].OnField = this;
                _playersonfield.Add(GameLogic.Playerlist[2]);
                _place.Controls.Add(GameLogic.Playerlist[2].picturebox);
                GameLogic.Playerlist[2].picturebox.Location = new Point(18, 18);

                if (i > 3)
                {
                    GameLogic.Playerlist[4].OnField = this;
                    _playersonfield.Add(GameLogic.Playerlist[4]);
                    _place.Controls.Add(GameLogic.Playerlist[4].picturebox);
                    GameLogic.Playerlist[4].picturebox.Location = new Point(67, 18);
                }
            }
        }

        

        public new void StepOn(Player player) 
        {
            player.MoneyTransfer(200);
            Positioning(player);
        }

        public void StepOver(Player player, bool monney ) // kein rückwertz 
        {
            player.MoneyTransfer(200);
            GoOver(player);
        }

        public new async void GoOver(Player player)
        {
            _place.Controls.Add(player.picturebox);
            int time = 300;
            int y = 0;
            int x = 91 - 30 -15;

            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            y = 40;
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            x = _place.Height - 30;
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
        }

        private new void Positioning(Player player)
        {
            player.OnField = this;
            _playersonfield.Add(player);
            _place.Controls.Add(player.picturebox);
           
        }

        private new void Positioning()
        {
            bool TwoPlayerOnField = false;
            if (_playersonfield.Count > 1) TwoPlayerOnField = true;

            _playersonfield[0].picturebox.Location = new Point(_place.Width / 2 - 15, 10);
            if (TwoPlayerOnField) _playersonfield[1].picturebox.Location = new Point(10, _place.Height / 2 - 15);
        }

        public new void LeaveField(Player player)
        {

            _playersonfield.Remove(player);
            _place.Controls.Remove(player.picturebox);

            if (_playersonfield.Count > 0)
                Positioning();
        }


    }
}

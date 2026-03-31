using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Kapitalismusly 
{
    internal class Jail : Field
    {
        private List<(Player, int)> _injail = new List<(Player, int)>();
        
        private Panel _parkplatz;
        public Jail(Panel panel,Panel Parkplatz)
        {
            _name = "Gefängnis";
            _place = panel;
            _parkplatz = Parkplatz;
            
        }

        

        public void GoInJail(Player player)
        {
            player.OnField = this;
            _injail.Add((player,0));
            PositioningJail(player);
            
            
        }

        private void PositioningJail(Player player)
        {

        }

        public void LeaveJail(Player player)
        {
            foreach (var item in _injail)
            {
                if (item.Item1 == player) _injail.Remove(item);
            }
        }

        public bool JailChek(Player player)
        {
            foreach (var item in _injail)
            {
                if (item.Item1 == player) return true;
            }

            return false;
        }

        public bool Knastausbruch(Player player, (int, int) i)
        {

            for (int j = 0; j < GameLogic.JailFreeCard.Length; j++)
            {
                if (GameLogic.JailFreeCard[j] == player)
                {
                    var result = MessageBox.Show("Du hast eine Gefängnisfreikarte.\nWillst du diese nutzen","", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Du kommst frei!");
                        GameLogic.JailFreeCard[j] = null;
                        return true;
                    }
                    break;

                }
            }


            int temp = 0;
            foreach (var item in _injail)
            {
                if (item.Item1 == player) temp = _injail.IndexOf(item); break;
            }



            if (i.Item1 != i.Item2)
            {
                _injail[temp] = (player, _injail[temp].Item2 + 1);
                if (_injail[temp].Item2 == 3)
                {
                    LeaveJail(player);
                }
                return false;
            }
            else
            {
                MessageBox.Show("Du bist frei! Würfle nochmal");
                return true;
            }
        }


        public new void StepOn(Player player)
        {
            player.OnField = this;
            _playersonfield.Add(player);
            Positioning(player);
        }

        public new async void GoOver(Player player)
        {
            _place.Controls.Add(player.picturebox);
            int time = 300;
            int y = _place.Width - 91 + 15;
            int x = 0;

            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            x = _place.Height - 91 + 15; ;
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);
            y = 0;
            player.picturebox.Location = new Point(y, x);
            await Task.Delay(time);

        }

        private new void Positioning(Player player)
        {
            _parkplatz.Controls.Add(player.picturebox);
            Positioning();
        }

        private new void Positioning() //Zu besuch
        {

            bool OnePlayerOnField = true;
            if (_playersonfield.Count > 1) OnePlayerOnField = false;


            if (OnePlayerOnField)
                _playersonfield[0].picturebox.Location = new Point(_parkplatz.Width / 2 - 15, _parkplatz.Height / 2 - 15);
            else
            {
                _playersonfield[0].picturebox.Location = new Point(_parkplatz.Width / 2 - 15, 22);
                _playersonfield[1].picturebox.Location = new Point(_parkplatz.Width / 2 - 15, 30 + 44);
            }
        }

        public new void LeaveField(Player player)
        {

            _playersonfield.Remove(player);
            _parkplatz.Controls.Remove(player.picturebox);

            if (_playersonfield.Count > 0)
                Positioning();


        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public new void StepOn(Player player)
        {
            player.OnField = this;
            _playersonfield.Add(player);
        }

        public void GoInJail(Player player)
        {
            player.OnField = this;
            _injail.Add((player,0));
            PositioningJail(player);
            
            
        }

        public void LeaveJail(Player player)
        {
            foreach (var item in _injail)
            {
                if (item.Item1 == player) _injail.Remove(item);
            }
        }

        public void Move(Player player)
        {
            // mach selber

        }

        private new void Positioning(Player player)
        {
            
        }

        private void PositioningJail(Player player)
        {

        }

        public bool JailChek(Player player)
        {
            foreach (var item in _injail)
            {
                if (item.Item1 == player) return true;
            }

            return false;
        }

        public bool Knastausbruch(Player player , (int,int) i)
        {

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
    }
}

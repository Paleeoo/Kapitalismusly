using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class Field
    {
        protected string _name;
        protected List<Player> _playersonfield = new List<Player>();
        protected Panel _place;

        public String Name
        {
            get { return _name; }
            set { return; }
        }


        public void StepOver(Player player)
        {
            _place.Controls.Add(player.picturebox);


        }

        public void StepOn(Player player)
        {
            

        }

        private void Move(bool richtung, Player player)
        {
            if (_place.Width > _place.Height)
            {
                if (!richtung)
                {  // move nach unten

                    int x = _place.Width - 56;
                    int y = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        y += 30;
                    }
                }
                else
                {
                    int x = 56;
                    int y = _place.Height;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        y -= 30;
                    }
                }
            }
            else
            {
                if (!richtung)
                {  // move nach unten

                    int x = 0;
                    int y = _place.Height - 56;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        x -= 30;
                    }
                }
                else
                {
                    int x = 0;
                    int y = 56;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        x += 30;
                    }
                }
            }
        }
    }
}

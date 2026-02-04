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
        protected bool _direction;

        public String Name
        {
            get { return _name; }
            set { return; }
        }


        public void StepOver(Player player, bool richtung)
        {
            _place.Controls.Add(player.picturebox);

            if (richtung) Move(player);
           
        }

        protected void Positioning(Player player)  //fixme
        {
            _playersonfield.Add(player);
            _place.Controls.Add(player.picturebox);
            bool OnePlayerOnField = true;
            if (_playersonfield.Count >1) OnePlayerOnField = false;

            if (_place.Width > _place.Height)  //Fields left and right
            {

                if (_direction) //Fields right site
                {
                    if (OnePlayerOnField)
                    {
                        player.picturebox.Location = new Point(10, 20);
                        MessageBox.Show("");
                    }

                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(10, 2);
                        _playersonfield[1].picturebox.Location = new Point(10, _place.Height - 30 -2);
                    }

                }
                else
                {
                    if (OnePlayerOnField) player.picturebox.Location = new Point(_place.Width - 30 - 10, 20);

                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(_place.Width - 30 - 10, 2);
                        _playersonfield[1].picturebox.Location = new Point(_place.Width - 30 - 10, _place.Height - 30 - 2);
                    }
                }
            }
            else//Felder unten und oben
            {
                if (_direction) //felder unten
                {
                    if (OnePlayerOnField) player.picturebox.Location = new Point(20, 10);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(_place.Width - 30 - 2, 10);
                        _playersonfield[1].picturebox.Location = new Point(2, 10);
                    }

                }
                else // oben
                {
                    if (OnePlayerOnField) player.picturebox.Location = new Point(20, _place.Height - 10);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(_place.Width - 30 - 2, _place.Height-30-10);
                        _playersonfield[1].picturebox.Location = new Point(2, _place.Height-30-10);
                    }
                }


            }
            MessageBox.Show(""); //entfernen wenn fertig
        }

        protected void Move( Player player)
        {
            if (_place.Width > _place.Height)  //Fields left an right
            {               
                if (_direction)  
                {  // move nach unten

                    int y = _place.Width - 40;
                    int x = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        x += 30;
                    }
                }
                else
                {
                    int y = 10;
                    int x = _place.Height;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        x -= 30;
                    }
                }
            }
            else//Felder unten und oben
            {
                if (_direction)
                {  // move nach links

                    int y = _place.Width;
                    int x = _place.Height - 40;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        y -= 30;
                    }
                }
                else // move nach rechts
                {
                    int y = 0;
                    int x = 10;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        MessageBox.Show("fd");
                        x += 30;
                    }
                }
            }
        }
        public void LeaveField(Player player)
        {
            //abfrage ob plyer in der liste ist

            _playersonfield.Remove(player);

            if (_playersonfield.Count > 0) StepOn(_playersonfield[0]);
            

        }
    }
}

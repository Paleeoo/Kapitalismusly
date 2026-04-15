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

        public virtual void StepOn(Player player)
        {
            //unbeschrieben wiel in jerder klasse neu definiert
        }
        public virtual void StepOn(Player player, int i)
        {
            //unbeschrieben wiel in klasse neu definiert
        }

        public virtual void StepOver(Player player)
        {
            GoOver(player);
        }

        public virtual async void GoOver(Player player)
        {
            _place.Controls.Add(player.picturebox);
            int time = 300;


            if (_place.Width > _place.Height)  //Fields left an right
            {

                if (_direction)
                {  // move right fields

                    int y = _place.Width - 91 +15;
                    int x = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        await Task.Delay(time);
                        x += 30;
                    }
                }
                else //left fields
                {
                    int y = 91 - 30 -15; 
                    int x = _place.Height;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        await Task.Delay(time);
                        x -= 30;
                    }
                }
            }
            else//Felder unten und oben
            {
                if (_direction)
                {  // field below

                    int y = _place.Width;
                    int x = _place.Height - 91 + 15 ;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        await Task.Delay(time);
                        y -= 30;
                    }
                }
                else // Field top
                {
                    int y = 0;
                    int x = 19 - 30 -15;
                    for (int i = 0; i < 2; i++)
                    {
                        player.picturebox.Location = new Point(y, x);
                        await Task.Delay(time);
                        x += 30;
                    }
                }
            }
            _place.Controls.Remove(player.picturebox);
        }

        public virtual void GoBack(Player player)
        {
            _place.Controls.Add(player.picturebox);

            if (_place.Width > _place.Height)  //Fields left
            {
                int y = 10;
                int x = 0;
                for (int i = 0; i < 2; i++)
                {
                    player.picturebox.Location = new Point(y, x);
                    MessageBox.Show("fd");
                    x += 30;
                }
            }
            else//Fields below
            {
                int y = 0;
                int x = _place.Height - 40;
                for (int i = 0; i < 2; i++)
                {
                    player.picturebox.Location = new Point(y, x);
                    MessageBox.Show("fd");
                    y += 30;
                }

            }
            _place.Controls.Remove(player.picturebox);
        }

        protected void Positioning(Player player)
        {
            player.OnField = this;
            _playersonfield.Add(player);
            _place.Controls.Add(player.picturebox);
            Positioning();
        }

        protected void Positioning()  
        {
            bool OnePlayerOnField = true;
            if (_playersonfield.Count >1) OnePlayerOnField = false;
            int w = _place.Width;
            int h = _place.Height;

            if (_place.Width > _place.Height)  //Fields left and right
            {

                if (_direction) //Fields right site
                {
                    if (OnePlayerOnField)
                        _playersonfield[0].picturebox.Location = new Point(_place.Width - 30 - 10, 20);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(_place.Width - 40, 4);
                        _playersonfield[1].picturebox.Location = new Point(_place.Width - 40, 30 + 8);
                    }

                }
                else
                {
                    if (OnePlayerOnField)
                        _playersonfield[0].picturebox.Location = new Point( 10, 20);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point( 10, 30 + 8);
                        _playersonfield[1].picturebox.Location = new Point( 10, 4);
                    }
                }
            }
            else//Felder unten und oben
            {
                if (_direction) //felder unten
                {
                    if (OnePlayerOnField) 
                        _playersonfield[0].picturebox.Location = new Point(20, _place.Height - 30 -10);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(30 + 8, _place.Height - 30 - 10);
                        _playersonfield[1].picturebox.Location = new Point(4, _place.Height - 30 - 10);
                    }
                }
                else // oben
                {
                    if (OnePlayerOnField)
                        _playersonfield[0].picturebox.Location = new Point(20, 10);
                    else
                    {
                        _playersonfield[0].picturebox.Location = new Point(4, 10);
                        _playersonfield[1].picturebox.Location = new Point(30 + 8, 10);
                    }
                }
            }
        }

       
        public virtual void LeaveField(Player player)
        {

            _playersonfield.Remove(player);
            _place.Controls.Remove(player.picturebox);

            if(_playersonfield.Count > 0) 
                Positioning();
            

        }


        public void TestMessegBox()
        {
            MessageBox.Show("");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    public partial class AllStreets : Form
    {
        private List<Street> _playerStreets = new List<Street>();
        private StreetPanel[,] _streetPages;
        private int _maxspage;
        private int _page = 0;
        Street aktuelStreet;

        private AllStreets(List<Street> templ)
        {
            InitializeComponent();
            label2.Text = GameLogic.PlayeronZug.Money.ToString() + "€";
            templ.ForEach(xx => _playerStreets.Add(xx));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            _maxspage = 1;
            _maxspage += _playerStreets.Count / 14;

            _streetPages = new StreetPanel[14, _maxspage];

            int s = 0;
            int zähler = 0;

            int y = 44;
            int x = 100;

            while (true)
            {
                if (_playerStreets.Count == 0)
                    return;

                Street tempSTreet = _playerStreets[0];
                CreatePannel(tempSTreet, y, x, zähler, s);
                zähler++;
                if (y == 1208)
                {
                    y = 44;

                    if (x == 100)
                        x = 385;
                    else
                    { x = 100; s++; zähler = 0; }
                }
                else
                    y += 190;

                foreach (var item in tempSTreet.streetfamaly)
                {
                    if (item != tempSTreet && _playerStreets.Contains(item))
                    {
                        CreatePannel(item, y, x, zähler, s);
                        _playerStreets.Remove(item);

                        if (y == 1208)
                        {
                            y = 44;

                            if (x == 100)
                                x = 385;
                            else
                            { x = 100; s++; zähler = 0; }
                        }
                        else
                            y += 190;
                    }
                }
            }
        }

        private void CreatePannel(Street str, int y, int x, int z, int s)
        {
            StreetPanel temp = new StreetPanel(str);
            temp.Location = new Point(y, x);
            temp.Click += (sender, g) => StreetPannelClic(temp);
            _streetPages[z, s] = temp;
        }

        private void Interface()
        {
            foreach (var item in _streetPages)
            {
                item.Visible = false;
                item.Enabled = false;
            }
            button3.Visible = false;
            button3.Enabled = false;
            aktuelStreet = null;

            for (int i = 0; i < 14; i++)
            {
                _streetPages[i, _page].Enabled = true;
                _streetPages[i, _page].Visible = true;
            }

            if (_page == 0)
            { button1.Visible = false; button1.Enabled = false; }
            else
            { button1.Visible = true; button1.Enabled = true; }

            if (_page < _maxspage)
            { button2.Visible = true; button2.Enabled = true; }
            else
            { button2.Visible = false; button2.Enabled = false; }
        }

        private void StreetPannelClic(StreetPanel p)
        {
            if (p.Street.StreetFammelyQuery() && p.Street.GetType() ==  typeof(StreetWithHous)&& p.Street.Houscount < 5)
            {
                button3.Visible = true;
                button3.Enabled = true;
                button3.Text = "Haus kaufen -" + p.Street.HousPrice.ToString() + "€";
            }
            else
            {
                button3.Visible = false;
                button3.Enabled = false;
            }
            foreach (var item in _streetPages)
            {
                item.BorderStyle = BorderStyle.None;
            }
            p.BorderStyle = BorderStyle.Fixed3D;
            aktuelStreet = p.Street;
        }


        private void AllStreets_Load(object sender, EventArgs e)
        {
            Interface();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aktuelStreet.BuyHous();
            if (aktuelStreet.Houscount > 4)
            {
                button3.Visible = false;
                button3.Enabled = false;
            }
            label2.Text = GameLogic.PlayeronZug.Money.ToString() + "€";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _page++;
            Interface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _page--;
            Interface();
        }

        internal static void SartVerkauf()
        {
            AllStreets allstreets = new AllStreets(GameLogic.PlayeronZug.Streets);
            allstreets.ShowDialog();
        }
    }
}


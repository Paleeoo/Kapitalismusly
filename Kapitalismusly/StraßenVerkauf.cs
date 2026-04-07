using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    public partial class StraßenVerkauf : Form
    {
        private int _debts;
        private int _salesMoney = 0;
        private List<Street> _playerStreets = new List<Street>();
        private List<Street> _streetToSell = new List<Street>();
        private StreetPanel[,] _streetPages;
        private int _maxspage;
        private int _page = 0;

        private StraßenVerkauf(List<Street> templ , int debts)
        {
            InitializeComponent();
            _debts = debts;
            templ.ForEach(xx => _playerStreets.Add(xx));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            label2.Text = (_debts + _salesMoney).ToString() + "€";

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
            if (p.Aktiv)
            {
                p.Aktiv = false;
                p.BorderStyle = BorderStyle.None;
                p.BackColor = Color.White;
                _streetToSell.Remove(p.Street);
                _salesMoney -= p.Street.Wert;
                label2.Text = (_debts + _salesMoney).ToString() + "€";
                if (_debts + _salesMoney < 0)
                {
                    label2.ForeColor = Color.Red;
                    button3.BackColor = Color.LightGray;
                    button3.Enabled = false;
                }
                    
            }
            else
            {
                p.Aktiv = true;
                p.BorderStyle = BorderStyle.Fixed3D;
                p.BackColor = Color.Red;
                _streetToSell.Add(p.Street);
                _salesMoney += p.Street.Wert;
                label2.Text = (_debts + _salesMoney).ToString() + "€";
                if (_debts + _salesMoney >= 0)
                {
                    label2.ForeColor = Color.Green;
                    button3.BackColor = Color.Red;
                    button3.Enabled = true;
                }
            }
        }


        private void StraßenVerkauf_Load(object sender, EventArgs e)
        {
            Interface();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (var item in _playerStreets)
            {
                item.Owner.MoneyTransfer(item.Wert);
                item.BackToBank();
            }
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

        internal static void SartVerkauf(List<Street> listtemp, int debts)
        {
            StraßenVerkauf straßenVerkauf = new StraßenVerkauf(listtemp, debts);
            straßenVerkauf.ShowDialog();

        }
    }

    internal partial class StreetPanel : Panel
    {
        public bool Aktiv = false;
        public readonly Street Street;

        public StreetPanel(Street street)
        {
            this.Size = new Size(150, 250);
            Street = street;

            Label label1 = new Label();
            label1.Text = Street.Name;
            label1.Location = new Point(0, 40);
            label1.AutoSize = false;
            label1.Size = new Size(150, 30);
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = new Font("Arial", 12);

            Label label2 = new Label();
            label2.Text = Street.Wert.ToString() + "€";
            label2.Location = new Point(0, 200);
            label2.AutoSize = false;
            label2.Size = new Size(150, 30);
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Font = new Font("Arial", 12);

            if (Street.GetType() != typeof(StreetWithHous))
                return;
            Label label3 = new Label();
            label3.Text = Street.Houscount.ToString() + " Häuser";
            label3.Location = new Point(0, 230);
            label3.AutoSize = false;
            label3.Size = new Size(150, 30);
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Font = new Font("Arial", 12);
        }
    }
}

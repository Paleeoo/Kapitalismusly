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
    public partial class Auction : Form
    {
        private int Wert = 0;
        private Player Höchstbietender;
        private List<MultiPanel> panellist = new List<MultiPanel>();
        private decimal time = 10.00m;
        private string _name;



        private Auction(string name)
        {
            Name = name;
            InitializeComponent();
            AddMultipanel();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
        }

        private void Auction_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Heute wird: "  + _name + "\nStartgebot ist 5€.\nErhöt wird ebenfals um 5€");
            timer1.Enabled = true;
        }

        private void AddMultipanel()
        {
            int count = GameLogic.Playerlist.Count;

            if (count == 2 || count == 4)
            {
                MultiPanel temp = new MultiPanel(GameLogic.Playerlist[0], this.Width / 2 - 40 - 150, 280);
                temp.Click += (sender, e) => MultiBoxCilck(temp) ;
                panellist.Add(temp);
                MultiPanel temp2 = new MultiPanel(GameLogic.Playerlist[1], this.Width / 2 + 40, 280);
                temp2.Click += (sender, e) => MultiBoxCilck(temp2);
                panellist.Add(temp2);
            }
            else if (count == 3)
            {
                MultiPanel temp = new MultiPanel(GameLogic.Playerlist[0], this.Width / 2 - 75, 280);
                temp.Click += (sender, e) => MultiBoxCilck(temp);
                panellist.Add(temp);
                MultiPanel temp2 = new MultiPanel(GameLogic.Playerlist[1], this.Width /2 - 80 - 150, 280);
                temp2.Click += (sender, e) => MultiBoxCilck(temp2);
                panellist.Add(temp2);
                MultiPanel temp3 = new MultiPanel(GameLogic.Playerlist[2], this.Width / 2 + 75 + 80,280);
                temp3.Click += (sender, e) => MultiBoxCilck(temp3);
                panellist.Add(temp3);
            }
            if (count == 4)
            {
                MultiPanel temp = new MultiPanel(GameLogic.Playerlist[2], 80 , 280);
                temp.Click += (sender, e) => MultiBoxCilck(temp);
                panellist.Add(temp);
                MultiPanel temp2 = new MultiPanel(GameLogic.Playerlist[3], this.Width - 80 - 150, 280);
                temp2.Click += (sender, e) => MultiBoxCilck(temp2);
                panellist.Add(temp2);
            }
        }

        private void MultiBoxCilck(MultiPanel m)
        {
            if (m.Player.Money >= Wert + 5)
                return;

            m.Enabled = false;
            Wert += 5;
            time = 5.00m;
            label4.Text = Wert.ToString() + "€";
            Höchstbietender = m.Player;
            label2.Text = m.Player.Name;

            foreach (var item in panellist)
            {
                item.BorderStyle = BorderStyle.None;
                if (item.Player.Money >= Wert + 5 && item.Player != m.Player)
                {
                    item.BackColor = Color.Red;
                    item.Enabled = false;
                }
            }

            m.BorderStyle = BorderStyle.Fixed3D;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 0.01m;
            label5.Text = (time.ToString() + "S");
            if (time != 0.00m)
                return;

            foreach (var item in panellist)
                item.Enabled = false;

            if (Höchstbietender == null)
                MessageBox.Show("Die Straße wurde nicht verkauft.");

            MessageBox.Show("Die Auktion ist vorbei!!!\nDer Höstbietende ist " + Höchstbietender.Name);
            this.Close();
        }

        internal static void StartNewAuction(out Player player, out int wert, string name)
        {
            Auction auction = new Auction(name);
            auction.ShowDialog();


            player = auction.Höchstbietender;
            wert = auction.Wert;
        }
    }

    public partial class MultiPanel : Panel
    {
        internal readonly Player Player;
        public PictureBox PictureBox;


        internal MultiPanel(Player player, int y, int x)
        {
            Player = player;
            this.Size = new Size(150, 300);

            Label label1 = new Label();
            label1.AutoSize = false;
            label1.Location = new Point(0, 20);
            label1.Size = new Size(150, 30);
            label1.Text = player.Name;
            label1.Font = new Font("Aral", 12);
            label1.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label1);
            
            PictureBox = new PictureBox();
            PictureBox.Size = new Size(100, 100);
            PictureBox.Location = new Point(25, 100);
            PictureBox.BackColor = player.picturebox.BackColor;  //sobald figuren dasind ändern
            this.Controls.Add(PictureBox);

            Label label2 = new Label();
            label2.AutoSize = false;
            label2.Location = new Point(0, 235);
            label2.Size = new Size(150, 30);
            label2.Text = player.Money.ToString() + "€";
            label2.Font = new Font("Aral", 12);
            label2.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(label2);
        }
    }
}



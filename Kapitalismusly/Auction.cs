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
        public Auction()
        {
            InitializeComponent();
        }

        private void Auction_Load(object sender, EventArgs e)
        {

        }




    }

    public partial class MultiPanel : Panel
    {
        private Player _player;
        public PictureBox PictureBox;


        internal MultiPanel(Player player)
        {
            _player = player;
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



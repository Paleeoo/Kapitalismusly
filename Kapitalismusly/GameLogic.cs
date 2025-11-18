using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal static class GameLogic
    {
        public static List<Player> Playerlist = new List<Player>();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
            Begin();
        }

        public static void Begin()
        {
            int Playercout = 2;


            PictureBox p1 = new PictureBox();
            p1.Size = new System.Drawing.Size(30, 30);
            p1.BackColor = Color.Purple;
            Player pl1 = new Player("Player 1", p1);

            

            


        }
    }
}

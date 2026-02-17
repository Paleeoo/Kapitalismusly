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
        public static Player PlayeronZug;
        public static List<Field> GameField = new List<Field>();
        public static List<Player> Playerlist = new List<Player>();
        static Form UI = new UI();
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/
            
            UI.Show();
            Test();
            
        }

        public static void Test()
        {  
            int Playercout = 2;


            PictureBox p1 = new PictureBox();
            p1.Size = new System.Drawing.Size(30, 30);
            p1.BackColor = Color.Purple;
            Player pl1 = new Player("Player 1", p1);

            //GameField[0].StepOver(pl1,true);
            //GameField[0].StepOn(pl1);





        }

        private static void PlayerSwitch()
        {

        }
    }
}

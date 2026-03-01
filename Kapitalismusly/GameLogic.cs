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
        public static Jail Guantanamo;  //einfach nur das knastfeld
        private static int _paschcount = 1;

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

        public static void Round(int Würfel1, int Würfel2)
        {
          
            if (PlayeronZug.OnField.GetType() != typeof(Jail) && !Guantanamo.JailChek(PlayeronZug))
            {
                if (_paschcount == 3) GoToJail();
            }
            else
            {
                if (Guantanamo.Knastausbruch(PlayeronZug, (Würfel1, Würfel2)))
                {
                    // Ui aktivate würfel
                    return;
                }
            }
        

        }

        private static void RoundEnd()
        {

        }

        public static void GoToJail()
        {
            int posi = GameField.IndexOf(PlayeronZug.OnField);
            PlayeronZug.LeaveField();
            if (posi > 29 || posi < 10)
            {
                PlayeronZug.OnField.LeaveField(PlayeronZug);
                for (int i = posi + 1;  i!= 10;i++)
                {
                    if (i == GameField.Count) i = 0;
                    GameField[i].GoOver(PlayeronZug);
                }
            }
            else
            {
                for (int i = posi - 1; i > 10 ; i--)
                {
                    GameField[i].GoBack(PlayeronZug);
                }
            }

            Guantanamo.GoInJail(PlayeronZug);
        }
    }
}

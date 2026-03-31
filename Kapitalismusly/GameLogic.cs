using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal static class GameLogic
    {
        public static Player[] JailFreeCard = new Player[3];
        public static Player PlayeronZug;
        public static List<Field> GameField = new List<Field>();
        public static List<Player> Playerlist = new List<Player>();
        public static UI Ui;
        public static Jail Guantanamo;  //einfach nur das knastfeld
        private static int _paschcount = 0;
        

        private static bool _nomoreplayer = false;
        public static bool NoMorePlayer
        {
            get { return _nomoreplayer; }
            set
            {
                if (_nomoreplayer) return;
                _nomoreplayer = value;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Ui = new UI();
            //BeforStart();


            Application.Run(Ui);
            Ui.Show();
            Testt();

            MessageBox.Show("");
        }

        private static void BeforStart()
        {
            CreatePlayer.AddPlayer();
            MessageBox.Show("Spieler erstellt.\nNächster Spieler ist dran.");
            CreatePlayer.AddPlayer();

            NoMorePlayer = true;
            return;

            while (true) //Fals mal mehr als 2 spieler möglich sind 
            {
                DialogResult temp = MessageBox.Show("Ein witeren Spieler erstellen?", "", MessageBoxButtons.YesNo);
                if (temp == DialogResult.No)
                {
                    NoMorePlayer = true;
                    return;
                }
                CreatePlayer.AddPlayer();

                if (Playerlist.Count == 4)
                {
                    NoMorePlayer = true;
                    return;
                }
            }
        }
        
        public static void Testt()
        {
            Ui.ActivateButtonRoll();
           
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
                if (Würfel1 == Würfel2)
                {
                    _paschcount++;
                    MessageBox.Show("Du hast zu oft ein Pasch gewürfelt.\nDu schummelst...\nGeh ins Gefängnis!");
                    if (_paschcount == 3) GoToJail();
                }

                int temp = GameField.IndexOf(PlayeronZug.OnField) + 1;
                PlayeronZug.LeaveField();
                for (int i = 1; i < Würfel1 + Würfel2; i++)
                {
                    if (temp == GameField.Count) temp = 0;
                    GameField[temp].StepOver(PlayeronZug);
                    temp++;
                }
                GameField[temp].StepOn(PlayeronZug);

                if (Würfel1 == Würfel2)
                {
                    MessageBox.Show("Du kannst nochmal Würfeln.");
                    // Ui aktivate würfel
                    return;
                }
            }
            else
            {
                if (Guantanamo.Knastausbruch(PlayeronZug, (Würfel1, Würfel2)))
                {
                    MessageBox.Show("Du kannst nochmal Würfeln.");
                    // Ui aktivate würfel
                    return;
                }
                else RoundEnd(); return;
            }
            Ui.ActivateButtonNext();
            
        }

        public static void RoundEnd()
        {
            if (Playerlist.IndexOf(PlayeronZug) == Playerlist.Count - 1) PlayeronZug = Playerlist[0];
            else PlayeronZug = Playerlist[Playerlist.IndexOf(PlayeronZug) + 1];
            // ui neue runde
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
            RoundEnd();
        }
    }
}

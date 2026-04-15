using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
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
            BeforStart();


            Application.Run(Ui);
            
        }

        private static void BeforStart()
        {
            PictureBox temp2 = new PictureBox();
            temp2.Size = new Size(30, 30);
            temp2.BackColor = Color.Purple;

            PictureBox temp1 = new PictureBox();
            temp1.Size = new Size(30, 30);
            temp1.BackColor = Color.Yellow;

            Playerlist.Add(new Player("p1", temp2));
            Playerlist.Add(new Player("p2", temp1));
            PlayeronZug = Playerlist[0];
            return;
            CreatePlayer.AddPlayer();
            MessageBox.Show("Spieler erstellt.\nNächster Spieler ist dran.");
            CreatePlayer.AddPlayer();

            Spielerreinenfolge.SortPlayer();
            NoMorePlayer = true;
            return;

            while (true) //Fals mal mehr als 2 spieler möglich sind 
            {
                DialogResult temp = MessageBox.Show("Ein witeren Spieler erstellen?", "", MessageBoxButtons.YesNo);
                if (temp == DialogResult.No)
                    break;

                CreatePlayer.AddPlayer();

                if (Playerlist.Count == 4)
                    break;
            }

            Spielerreinenfolge.SortPlayer();
            NoMorePlayer = true;
        }

        public static void Round(int Würfel1, int Würfel2)
        {

            if (PlayeronZug.OnField.GetType() != typeof(Jail) && !Guantanamo.JailChek(PlayeronZug))
            {
                if (Würfel1 == Würfel2)
                {
                    _paschcount++;
                    if (_paschcount == 3)
                    {
                        MessageBox.Show("Du hast zu oft ein Pasch gewürfelt.\nDu schummelst...\nGeh ins Gefängnis!");
                        GoToJail();
                    }

                }

                int temp = GameField.IndexOf(PlayeronZug.OnField) + 1;
                PlayeronZug.LeaveField();
                for (int i = 1; i < Würfel1 + Würfel2; i++)
                {
                    if (temp == GameField.Count) temp = 0;
                    GameField[temp].StepOver(PlayeronZug);
                    temp++;
                }
                if (GameField[temp].GetType() == typeof(BasicServices))
                    GameField[temp].StepOn(PlayeronZug, Würfel1+ Würfel2);
                else
                    GameField[temp].StepOn(PlayeronZug);

                if (Würfel1 == Würfel2)
                {
                    MessageBox.Show("Du kannst nochmal Würfeln.");
                    Ui.ActivateButtonRoll();
                    return;
                }
            }
            else
            {
                if (Guantanamo.Knastausbruch(PlayeronZug, (Würfel1, Würfel2)))
                {
                    MessageBox.Show("Du kannst nochmal Würfeln.");
                    Ui.ActivateButtonRoll();
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

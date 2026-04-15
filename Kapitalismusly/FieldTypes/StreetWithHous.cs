using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitalismusly
{
    internal class StreetWithHous : Street
    {
        private Label _houseplace;

        private int _housecount;
        readonly public int HousPrice;
        public readonly int Grundmiete;
        public readonly int Miete1Haus;
        public readonly int Miete2Haus;
        public readonly int Miete3Haus;
        public readonly int Miete4Haus;
        public readonly int MieteHotell;

        public new int Houscount
        {
            get { return _housecount; }
            set { return; }
        }

        public StreetWithHous(string name, int preis, List<Street> list, int housprice, int grundmiete, int miete1haus, int miete2haus, int miete3haus, int miete4haus, int mietehotell, Panel place, Label housplace, bool richtung) : base(name, preis, place, richtung, list)
        {
            _housecount = 0;
            HousPrice = housprice;
            Grundmiete = grundmiete;
            Miete1Haus = miete1haus;
            Miete2Haus = miete2haus;
            Miete3Haus = miete3haus;
            Miete4Haus = miete4haus;
            MieteHotell = mietehotell;
            housplace.Text = "";
            _houseplace = housplace;
            
        }


        public override void StepOn(Player player)
        {
            Positioning(player);
            if (Owner == null) Kaufabfrage(player);

            else
            {
                if (player == _owner)
                {
                   
                }
                else
                {
                    if (_housecount == 0)
                    {
                        if (StreetFammelyQuery())
                            player.MoneyTransfer(Owner, Grundmiete * 2);
                        else
                            player.MoneyTransfer(Owner, Grundmiete);
                    }
                    else
                    {
                        switch (Houscount)
                        {
                            case 1: player.MoneyTransfer(_owner, Miete1Haus);
                                return;

                            case 2: player.MoneyTransfer(_owner, Miete2Haus);
                                return;

                            case 3: player.MoneyTransfer(_owner, Miete3Haus);
                                return;

                            case 4: player.MoneyTransfer(_owner, Miete4Haus);
                                return;

                            case 5: player.MoneyTransfer(_owner, MieteHotell);
                                return;
                        }

                        MessageBox.Show("fehler");
                    }
                    





                }
            }
        }

        public new void BuyHous()
        {
            if (Houscount == 5)
            {
                MessageBox.Show("Du hast schon ein Hottel");
                return;
            }

            if (_owner.Money >= HousPrice)
            {
                _housecount++;
                _houseplace.Text = Houscount.ToString();
                Owner.MoneyTransfer(-HousPrice);
            }
            else
                MessageBox.Show("Kannst du dir nicht leisten");
        
        }

        private void PlaceHous()
        {
            // Fixmeeeeee
        }

    }


}

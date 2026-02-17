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
        private Panel _houseplace = new Panel();

        private int _housecount;
        readonly public int HousPrice;
        public readonly int Grundmiete;
        public readonly int Miete1Haus;
        public readonly int Miete2Haus;
        public readonly int Miete3Haus;
        public readonly int Miete4Haus;
        public readonly int MieteHotell;

        public int Houscount
        {
            get { return _housecount; }
            set { return; }
        }

        public StreetWithHous(string name, int preis, List<Street> list, int housprice, int grundmiete, int miete1haus, int miete2haus, int miete3haus, int miete4haus, int mietehotell, Panel place, Panel housplace, bool richtung) : base(name, preis, place, richtung, list)
        {
            _housecount = 0;
            HousPrice = housprice;
            Grundmiete = grundmiete;
            Miete1Haus = miete1haus;
            Miete2Haus = miete2haus;
            Miete3Haus = miete3haus;
            Miete4Haus = miete4haus;
            MieteHotell = mietehotell;
            _houseplace = housplace;
        }


        public void StepOn(Player player)
        {
            Positioning(player);
            if (Owner == null) Kaufabfrage(player);

            else
            {
                if (player == _owner) return;
                else
                {
                    if (_housecount == 0)
                    {
                        foreach (var item in streetfamaly)
                        {
                            if (item.Owner != _owner) { player.MoneyTransfer(Owner, Grundmiete); return; }
                        }
                        player.MoneyTransfer(Owner, Grundmiete * 2);
                    }
                    else if (_housecount == 1) player.MoneyTransfer(_owner, Miete1Haus);
                    else if (_housecount == 2) player.MoneyTransfer(_owner, Miete2Haus);
                    else if (_housecount == 3) player.MoneyTransfer(_owner, Miete3Haus);
                    else if (_housecount == 4) player.MoneyTransfer(_owner, Miete4Haus);
                    else player.MoneyTransfer(Owner, Miete4Haus);
                }
            }
        }

        public void BuyHous()
        {
            if (_owner.Money >= HousPrice)
            {
                _housecount++;
                PlaceHous();
            }
        
        }

        private void PlaceHous()
        {
            // Fixmeeeeee
        }

    }


}

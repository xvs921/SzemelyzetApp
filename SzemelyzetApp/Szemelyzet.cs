using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemelyzetApp
{
    class Szemelyzet
    {
        Szemely fonok;

        public Szemelyzet(Szemely fonok)
        {
            this.fonok = fonok;
        }

        public Szemely Keres(string nev, DateTime szuletes)
        {
            return fonok.Keres(nev,szuletes);
        }

        public int Letszam
        {
            get
            {
                return fonok.Letszam;
            }
        }
        public void Listazas()
        {
            fonok.Listazas();
        }
        public int BeosztottakSzama
        {
            get
            {
                return fonok.BeosztottakSzama;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzemelyzetApp
{
    class Szemely:IComparable<Szemely>
    {
        readonly string nev;//a readonly-val jelölt változók értékét csak az objektum létrehozásánál változtathatjuk, később nem módosíthatók
        readonly string beosztas;
        DateTime szuletes;
        //java-ban: final a readonly-val megegyezik

        readonly ISet<Szemely> beosztottak=new SortedSet<Szemely>();//sortedset a bifa megvalósítást használja

        public Szemely(string nev, string beosztas, DateTime szuletes)
        {
            this.nev = nev;
            this.beosztas = beosztas;
            this.szuletes = szuletes;
        }

        public void Hozzaad(Szemely sz)
        {
            beosztottak.Add(sz);
        }

        internal Szemely Keres(string nev, DateTime szuletes)
        {
            if (this.nev.Equals(nev) && this.szuletes.Equals(szuletes))
            {
                return this;
            }
            foreach (var b in beosztottak)
            {
                var keresett = b.Keres(nev, szuletes);
                if (keresett!=null)
                {
                    return keresett;
                }
            }
            return null;
        }

        public string Nev => nev;

        public string Beosztas => beosztas;

        public DateTime Szuletes { get => szuletes; set => szuletes = value; }

        public int CompareTo(Szemely other)
        {//az összehasonlított elemeket nem érdmees megváltoztatni
            int i = this.nev.CompareTo(other.nev);
            if (i!=0)
            {
                return i;
            }
            return this.szuletes.CompareTo(other.szuletes);
        }

        public override string ToString()
        {
            return nev;
        }
        public int Letszam
        {
            get
            {
                var l = 1;
                foreach (var b in beosztottak)
                {
                    l += b.Letszam;
                }
                return l;
            }
        }
        public void Listazas()
        {
          Console.WriteLine(this.nev);
          foreach (var b in beosztottak)
          {
                b.Listazas();
          }
        }
        public int BeosztottakSzama
        {
            get
            {
                var l = 1;
                foreach (var b in beosztottak)
                {
                    l+=b.BeosztottakSzama;
                }
                return l;
            }
        }
    }
}

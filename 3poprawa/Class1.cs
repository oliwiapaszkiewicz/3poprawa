using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3poprawa
{
    public class Osoba
    {
        public int ID { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }

        public Osoba(int id, string imię, string nazwisko, int wiek, string stanowisko)
        {
            ID = id;
            Imię = imię;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Stanowisko = stanowisko;
        }
    }
}

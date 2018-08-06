using DapperExample.Models;
using System;
using Xunit;
using Xunit.Abstractions;
using ZarzadzanieSalamiApi.Models;

namespace ZarzadzanieSalami.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            // can be either of below
            //ZarzadzanieSalamiProvider p = new ZarzadzanieSalamiProvider("Server=sql-ag1-listen.pjwstk.edu.pl;Database=dziekanat_hash;Trusted_Connection=True;MultipleActiveResultSets=true");
            ZarzadzanieSalamiRepository p = new ZarzadzanieSalamiRepository("Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True");
            output.WriteLine(p.GetBudynek(1).Adres_budynku);
            //Budynek b = new Budynek
            //{
            //    Nazwa = "test",
            //    IdMiasto = 2411,
            //    Adres_budynku = "test",
            //    Opis = "test",
            //    Istnieje = true,
            //    IdKampus = 1
            //};
            //p.AddBudynek(b);

            //Sala s = new Sala
            //{
            //    Nazwa_sali = "testMaciek",
            //    Liczba_miejsc = 0,
            //    Pow_m2 = 10.57,
            //    Uwagi = "Sprz¹t.",
            //    IdBudynek = 1,
            //    Istnieje = true,
            //    IdFunkcja_sali = 19,
            //    Poziom = "Piwnica",
            //    Dostep_dla_niepelnosprawnych = false,
            //    Uzytkownik = "Serwis sprz¹taj¹cy",
            //    Kolejnosc = 0
            //    //IdRozkladSali = 0,
            //    //LiczbaKomputerow = 0,
            //    //IdKomputer = 0,
            //    //Klimatyzacja = false
            //};

            //p.AddSala(s);
        }
    }
}

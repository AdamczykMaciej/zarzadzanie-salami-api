using Autofac;
using Autofac.Configuration;
using ClassroomManagement.Models;
using ClassroomManagementApi.Controllers;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace ClassroomManagement.Tests
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
            string connectionString = "Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True";
            ClassroomManagementRepository p = new ClassroomManagementRepository();

            //Building b = new Building
            //{
            //    Nazwa = "test",
            //    IdMiasto = 2411,
            //    Adres_budynku = "test",
            //    Opis = "test",
            //    Istnieje = true,
            //    IdKampus = 1
            //};
            //p.AddBudynek(b);

            //Classroom c = new Classroom
            //{
            //    Nazwa_sali = "testmaciek222",
            //    Liczba_miejsc = 0,
            //    Pow_m2 = 10.57,
            //    Uwagi = "sprz�t.",
            //    IdBudynek = 1,
            //    Istnieje = true,
            //    IdFunkcja_sali = 19,
            //    Poziom = "piwnica",
            //    Dostep_dla_niepelnosprawnych = false,
            //    Uzytkownik = "serwis sprz�taj�cy",
            //    Kolejnosc = 0,
            //    //IdRozkladSali = 0,
            //    //LiczbaKomputerow = 20,
            //    //IdKomputer = 0,
            //    //Klimatyzacja = false
            //};

            //p.AddClassroom(c);
        }
    }
}

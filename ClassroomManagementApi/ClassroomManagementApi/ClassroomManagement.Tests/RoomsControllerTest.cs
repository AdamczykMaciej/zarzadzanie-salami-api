using ClassroomManagement.Models;
using ClassroomManagementApi.Controllers;
using ClassroomManagementApi.Models;
using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.Filtering;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace ClassroomManagement.Tests
{
    public class RoomsControllerTest
    {
        private readonly ITestOutputHelper output;

        public RoomsControllerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test()
        {
            var listOfClassrooms = new List<Classroom>();
            listOfClassrooms.Add(new Classroom
            {
                Nazwa_sali = "sala",
                Liczba_miejsc = 30,
                Pow_m2 = 30.5,
                Uwagi = "",
                IdBudynek = 1,
                Istnieje = true,
                IdFunkcja_sali = 1,
                Poziom = "0",
                Dostep_dla_niepelnosprawnych = true,
                Uzytkownik = "Maciek",
                Kolejnosc = 1,
                IdRozkladSali = 1,
                LiczbaKomputerow = 20,
                IdKomputer = 1,
                Klimatyzacja = true,

            });

            FilteringObject fo = new FilteringObject
            {
                AirConditioning = true
            };
            Mock<IClassroomManagementRepository> mockRepository = new Mock<IClassroomManagementRepository>();
            mockRepository.Setup(x => x.GetClassrooms()).Returns(listOfClassrooms);
            var roomsController = new RoomsController(mockRepository.Object);
            roomsController.MethodToTest();
            roomsController.Should().NotBeNull();
        }
    }
}

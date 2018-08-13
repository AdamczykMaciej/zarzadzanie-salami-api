using ClassroomManagement.Models;
using DapperExample.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using ZarzadzanieSalamiApi.Controllers;

namespace ZarzadzanieSalami.Tests
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
            //string connectionString = "Data Source=sql-ag1-listen.pjwstk.edu.pl;Initial Catalog=dziekanat_hash;Integrated Security=True";
            //ClassroomManagementRepository p = new ClassroomManagementRepository(connectionString);

            //var listOfClassrooms = new List<Classroom>();
            //listOfClassrooms.Add(new Classroom
            //{
            //    Nazwa_sali = "sala",
            //    Liczba_miejsc = 30
                
            //});
            //Mock<IClassroomManagementRepository> mockRepository = new Mock<IClassroomManagementRepository>();
            //mockRepository.Setup(x => x.GetClassrooms()).Returns(listOfClassrooms);
            //var roomsController = new RoomsController(mockRepository.Object);
            ////roomsController.GetClassrooms();
            //roomsController.Should().NotBeNull();
        }
    }
}

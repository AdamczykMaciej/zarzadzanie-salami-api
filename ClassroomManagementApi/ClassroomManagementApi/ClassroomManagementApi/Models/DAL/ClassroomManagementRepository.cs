using ClassroomManagementApi.Models.DAL;
using ClassroomManagementApi.Models.Filtering;
using Dapper;
using ClassroomManagementApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using ClassroomManagementApi.Models.DTO.Basic;
using ClassroomManagementApi.Models.DTO.ComputerDetails;

namespace ClassroomManagement.Models
{
    // CONVENTION: Polish names - DTO classes' fields to map data from the database
    public class ClassroomManagementRepository : IClassroomManagementRepository
    {
        private readonly string connectionString;

        public ClassroomManagementRepository()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            var conString = builder.Build().GetConnectionString("DefaultConnection");
            this.connectionString = conString;
        }

        // TODO: delete it: it is equivalent to the above
        public ClassroomManagementRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Building> GetBuildings()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_BudynekAll_sel;";
                try
                {
                    return connection.Query<Building>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public Building GetBuilding(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Budynek_sel @IdBudynek = @IdBudynek;";
                try
                {
                    return connection.Query<Building>(query, new { IdBudynek = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        //TODO: No records in Campus so I am not including Campus column here
        //TODO: Delete it not needed
        public void AddBuilding(Building building)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO Budynek (Nazwa, IdMiasto, Adres_budynku, Opis, Istnieje) VALUES (@Nazwa, @IdMiasto, @Adres_budynku, @Opis, @Istnieje);";
                try
                {
                    connection.Execute(query,
                        new
                        {
                            building.Nazwa,
                            building.IdMiasto,
                            building.Adres_budynku,
                            building.Opis,
                            building.Istnieje,
                        });
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public IEnumerable<ClassroomFunction> GetClassroomFunctions()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_FunkcjaSaliAll_sel;";
                try
                {
                    return connection.Query<ClassroomFunction>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public ClassroomFunction GetClassroomFunction(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_FunkcjaSali_sel @IdFunkcja_sali = @IdFunkcja_sali;";
                try
                {
                    return connection.Query<ClassroomFunction>(query, new { IdFunkcja_sali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<Campus> GetCampus()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Kampus;";
                try
                {
                    return connection.Query<Campus>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public Campus GetCampus(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Kampus_sel @IdKampus = @IdKampus;";
                try
                {
                    return connection.Query<Campus>(query, new { IdKampus = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<VirtualMachine> GetVirtualMachines()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna;";
                try
                {
                    return connection.Query<VirtualMachine>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public VirtualMachine GetVirtualMachine(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna WHERE IdMaszynaWirtualna = @IdMaszynaWirtualna;";
                try
                {
                    return connection.Query<VirtualMachine>(query, new { IdVirtualMachine = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<Monitor> GetMonitors()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Monitor;";
                try
                {
                    return connection.Query<Monitor>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }   
            }
        }

        public Monitor GetMonitor(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Monitor WHERE IdMonitor = @IdMonitor;";
                try
                {
                    return connection.Query<Monitor>(query, new { IdMonitor = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<Software> GetSoftware()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_OprogramowanieAll_sel;";
                try
                {
                    return connection.Query<Software>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public Software GetSoftware(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Oprogramowanie_sel @IdOprogramowanie;";
                try
                {
                    return connection.Query<Software>(query, new { IdOprogramowanie = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }   
            }
        }

        public IEnumerable<ComputerSoftware> GetComputerSoftware()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<ComputerSoftware> GetSoftwareForComputer(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdKomputer = @IdKomputer;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<ComputerSoftware> GetComputersForSoftware(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdOprogramowanie = @IdOprogramowanie;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }    
            }
        }

        public IEnumerable<Computer> GetComputers()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_KomputerAll_sel;";
                try
                {
                    return connection.Query<Computer>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } 
            }
        }

        public Computer GetComputer(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Komputer_sel @IdKomputer;";
                try
                {
                    return connection.Query<Computer>(query, new { IdKomputer = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } 
            }
        }

        public IEnumerable<ClassroomStructure> GetClassroomStructures()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali;";
                try
                {
                    return connection.Query<ClassroomStructure>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                } 
            }
        }

        public ClassroomStructure GetClassroomStructure(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali WHERE IdRozkladSali = @IdRozkladSali;";
                try
                {
                    return connection.Query<ClassroomStructure>(query, new { IdRozkladSali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }  
            }
        }

        public IEnumerable<Classroom> GetClassrooms()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_SalaAll_sel;";
                try
                {
                    return connection.Query<Classroom>(query);
                }
                // if the result is null then it throws InvalidOperationException
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IEnumerable<Classroom> FilterClassrooms(FilteringObject f)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //TODO: finish if statements, we will be filtering by names later not ids
                string query = @"EXEC zss_FilterSala_sel @BudynekA = @BuildingA, @BudynekB = @BuildingB,
                @BudynekC = @BuildingC, @IdFunkcja_sali = @IdClassroomFunction, @Klimatyzacja = @AirConditioning,
                @TV = @TV, @Projektor = @Projector, @TylkoSalaDydaktyczna = @OnlyEducationalClassrooms,
                @RozmiarSaliMin = @SizeMin, @RozmiarSaliMax = @SizeMax, @LiczbaMiejscMin = @PlacesMin, @LiczbaMiejscMax = @PlacesMax;";
                try
                {
                    // we return EducationalClassrooms because we want to get additional data for Classrooms which are EducationalClassrooms
                     return connection.Query<EducationalClassroom>(query, new { BuildingA = f.BuildingA, BuildingB = f.BuildingB, BuildingC = f.BuildingC, IdClassroomFunction = f.IdClassroomFunction, AirConditioning = f.AirConditioning, TV = f.TV, Projector = f.Projector, OnlyEducationalClassrooms = f.OnlyEducationalClassrooms, SizeMin = f.sizeMin, SizeMax = f.sizeMax, PlacesMin = f.placesMin, PlacesMax = f.placesMax});
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }  
            }
        }

        public Classroom GetClassroom(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Sala_sel @IdSala = @IdSala;";

                try
                {
                    return connection.Query<Classroom>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public void AddClassroom(Classroom s)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO dbo.Sala
                (Nazwa_sali, Liczba_miejsc, Pow_m2, Uwagi, IdBudynek, Istnieje, IdFunkcja_sali, Poziom, Dostep_dla_niepelnosprawnych, Uzytkownik, Kolejnosc, IdRozkladSali, LiczbaKomputerow, IdKomputer, Klimatyzacja) VALUES (@Nazwa_sali, @Liczba_miejsc, @Pow_m2, @Uwagi, @IdBudynek, @Istnieje, @IdFunkcja_sali, @Poziom, @Dostep_dla_niepelnosprawnych, @Uzytkownik, @Kolejnosc, @IdRozkladSali, @LiczbaKomputerow, @IdKomputer, @Klimatyzacja);";
                //TODO: delete queryOld
                const string queryOld = @"INSERT INTO dbo.Sala
                (Nazwa_sali, Liczba_miejsc, Pow_m2, Uwagi, IdBudynek, Istnieje, IdFunkcja_sali, Poziom, Dostep_dla_niepelnosprawnych, Uzytkownik, Kolejnosc) VALUES (@Nazwa_sali, @Liczba_miejsc, @Pow_m2, @Uwagi, @IdBudynek, @Istnieje, @IdFunkcja_sali, @Poziom, @Dostep_dla_niepelnosprawnych, @Uzytkownik, @Kolejnosc);";
                try
                {
                    connection.Execute(query,
                        new
                        {
                            s.Nazwa_sali,
                            s.Liczba_miejsc,
                            s.Pow_m2,
                            s.Uwagi,
                            s.IdBudynek,
                            s.Istnieje,
                            s.IdFunkcja_sali,
                            s.Poziom,
                            s.Dostep_dla_niepelnosprawnych,
                            s.Uzytkownik,
                            s.Kolejnosc,
                            s.IdRozkladSali,
                            s.LiczbaKomputerow,
                            s.IdKomputer,
                            s.Klimatyzacja
                        });
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public IEnumerable<EducationalClassroom> GetEducationalClassrooms()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_SalaDydaktycznaAll_sel;";
                try
                {
                    return connection.Query<EducationalClassroom>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
 
        public EducationalClassroom GetEducationalClassroom(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_SalaDydaktyczna_sel @IdSala = @IdSala;";
                try
                {
                    return connection.Query<EducationalClassroom>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
        //TODO: create procedures instead of select statements (no *)
        public IEnumerable<VirtualMachineComputer> GetVirtualMachineComputers()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"Select * From MaszynaWirtualnaKomputer;";
                try
                {
                    return connection.Query<VirtualMachineComputer>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public ComputerDetails GetComputerDetails(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string queryVirtualMachinesForComputer = @"EXEC zss_MaszynyWirtualneDlaKomputer_sel @IdKomputer = @IdKomputer ";
                const string queryComputer = @"EXEC zss_Komputer_sel @IdKomputer = @IdKomputer";
                try
                {
                    ComputerDetails cd = new ComputerDetails
                    {
                        ComputerInfo = connection.Query<Computer>(queryComputer, new { IdKomputer = id }).First(),
                        WirtualneMaszyny = connection.Query<VirtualMachine>(queryVirtualMachinesForComputer, new { IdKomputer = id })
                    };
                    return cd;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
    }
}

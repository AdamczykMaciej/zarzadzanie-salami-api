﻿using ClassroomManagementApi.Models.DAL;
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
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            IEnumerable<Building> buildings;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_BudynekAll_sel;";
                buildings = await connection.QueryAsync<Building>(query);
            }
            return buildings;
        }

        public Building GetBuilding(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Budynek_sel @IdBudynek = @IdBudynek;";
                try
                {
                    return connection.Query<Building>(query, new { IdBudynek = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<ClassroomFunction> GetClassroomFunctions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_FunkcjaSaliAll_sel;";
                try
                {
                    return connection.Query<ClassroomFunction>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public ClassroomFunction GetClassroomFunction(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_FunkcjaSali_sel @IdFunkcja_sali = @IdFunkcja_sali;";
                try
                {
                    return connection.Query<ClassroomFunction>(query, new { IdFunkcja_sali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Campus> GetCampus()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Kampus;";
                try
                {
                    return connection.Query<Campus>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public Campus GetCampus(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Kampus_sel @IdKampus = @IdKampus;";
                try
                {
                    return connection.Query<Campus>(query, new { IdKampus = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<VirtualMachine> GetVirtualMachines()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna;";
                try
                {
                    return connection.Query<VirtualMachine>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public VirtualMachine GetVirtualMachine(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna WHERE IdMaszynaWirtualna = @IdMaszynaWirtualna;";
                try
                {
                    return connection.Query<VirtualMachine>(query, new { IdVirtualMachine = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Monitor> GetMonitors()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Monitor;";
                try
                {
                    return connection.Query<Monitor>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public Monitor GetMonitor(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Monitor WHERE IdMonitor = @IdMonitor;";
                try
                {
                    return connection.Query<Monitor>(query, new { IdMonitor = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Software> GetSoftware()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_OprogramowanieAll_sel;";
                try
                {
                    return connection.Query<Software>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public Software GetSoftware(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Oprogramowanie_sel @IdOprogramowanie;";
                try
                {
                    return connection.Query<Software>(query, new { IdOprogramowanie = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<ComputerSoftware> GetComputerSoftware()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<ComputerSoftware> GetSoftwareForComputer(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdKomputer = @IdKomputer;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<ComputerSoftware> GetComputersForSoftware(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdOprogramowanie = @IdOprogramowanie;";
                try
                {
                    return connection.Query<ComputerSoftware>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Computer> GetComputers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_KomputerAll_sel;";
                try
                {
                    return connection.Query<Computer>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public Computer GetComputer(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Komputer_sel @IdKomputer;";
                try
                {
                    return connection.Query<Computer>(query, new { IdKomputer = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<ClassroomStructure> GetClassroomStructures()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali;";
                try
                {
                    return connection.Query<ClassroomStructure>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public ClassroomStructure GetClassroomStructure(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali WHERE IdRozkladSali = @IdRozkladSali;";
                try
                {
                    return connection.Query<ClassroomStructure>(query, new { IdRozkladSali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Classroom> GetClassrooms()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_SalaAll_sel;";
                try
                {
                    return connection.Query<Classroom>(query);
                }
                // if the result is null then it throws InvalidOperationException
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public IEnumerable<Classroom> FilterClassrooms(FilteringObject f)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"EXEC dbo.zss_FilterSala_sel @Budynki = @Buildings, @Klimatyzacja = @AirConditioning,
                @TV = @TV, @Projektor = @Projector, @TylkoSalaDydaktyczna = @OnlyEducationalClassrooms,
                @RozmiarSaliMin = @SizeMin, @RozmiarSaliMax = @SizeMax, @LiczbaMiejscMin = @PlacesMin, @LiczbaMiejscMax = @PlacesMax,
                @Dostep_dla_niepelnosprawnych = @AccessForTheDisabled, @FunkcjeSali = @ClassroomFunctions;";

                DataTable buildings = new DataTable();
                buildings.Columns.Add("Nazwa", typeof(string));

                if (f.Buildings != null)
                {
                    foreach (var item in f.Buildings)
                    {
                        buildings.Rows.Add(item);
                    }
                }

                DataTable classroomFunctions = new DataTable();
                classroomFunctions.Columns.Add("Nazwa", typeof(string));

                if (f.ClassroomFunctions != null)
                {
                    foreach (var item in f.ClassroomFunctions)
                    {
                        classroomFunctions.Rows.Add(item);
                    }
                }

                try
                {
                    // we return EducationalClassrooms because we want to get additional data for Classrooms which are EducationalClassrooms
                    return connection.Query<EducationalClassroom>(query, new { Buildings = buildings.AsTableValuedParameter("dbo.BudynekType"),
                        AirConditioning = f.AirConditioning, TV = f.TV, Projector = f.Projector, OnlyEducationalClassrooms = f.OnlyEducationalClassrooms, SizeMin = f.SizeMin,
                        SizeMax = f.SizeMax, PlacesMin = f.PlacesMin, PlacesMax = f.PlacesMax, AccessForTheDisabled = f.AccessForTheDisabled, ClassroomFunctions = classroomFunctions.AsTableValuedParameter("dbo.FunkcjaSaliType")});
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public Classroom GetClassroom(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Sala_sel @IdSala = @IdSala;";

                try
                {
                    return connection.Query<Classroom>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public void AddClassroom(EducationalClassroom c)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string addSala = @"EXEC dbo.zss_Sala_ins @Nazwa_sali = @Nazwa_sali, @Liczba_miejsc =  @Liczba_miejsc,
                @Pow_m2 = @Pow_m2, @Uwagi = @Uwagi,@IdBudynek = @IdBudynek, @Istnieje = @Istnieje,
                @IdFunkcja_sali = @IdFunkcja_sali, @Poziom = @Poziom, @Dostep_dla_niepelnosprawnych = @Dostep_dla_niepelnosprawnych,
                @Uzytkownik = @Uzytkownik, @Kolejnosc = @Kolejnosc,@IdRozkladSali = @IdRozkladSali,@LiczbaKomputerow = @LiczbaKomputerow,
                @IdKomputer = @IdKomputer, @Klimatyzacja = @Klimatyzacja;";

                const string addSalaDydaktyczna = @"INSERT INTO dbo.Sala_dydaktyczna
                (IdSala, Liczba_gniazd_sieciowych, TV, Projektor, Liczba_miejsc_dydaktycznych) 
                VALUES (@IdSala, @Liczba_gniazd_sieciowych, @TV, @Projektor, @Liczba_miejsc_dydaktycznych);";
                try
                {
                    int idClassroom = connection.Query<Classroom>(addSala,
                        new
                        {
                            c.Nazwa_sali,
                            c.Liczba_miejsc,
                            c.Pow_m2,
                            c.Uwagi,
                            c.IdBudynek,
                            c.Istnieje,
                            c.IdFunkcja_sali,
                            c.Poziom,
                            c.Dostep_dla_niepelnosprawnych,
                            c.Uzytkownik,
                            c.Kolejnosc,
                            c.IdRozkladSali,
                            c.LiczbaKomputerow,
                            c.IdKomputer,
                            c.Klimatyzacja
                        }).First().IdSala;

                    if(c.CzyDydaktyczna == true)
                    {
                        connection.Execute(addSalaDydaktyczna,
                            new
                            {
                                IdSala = idClassroom,
                                c.Liczba_gniazd_sieciowych,
                                c.TV,
                                c.Projektor,
                                c.Liczba_miejsc_dydaktycznych
                            });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }

            }
        }

        public void EditClassroom(EducationalClassroom c)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //try
                //{
                //    // FIRST: update the computer
                //    string updateClassroom = @"Update dbo.Classroom set 
                //    Nazwa_sali = @Nazwa_sali, Liczba_miejsc = @Liczba_miejsc, Pow_m2 = @Pow_m2, Uwagi = @Uwagi,
                //    IdBudynek = @IdBudynek, Istnieje = @Istnieje, IdFunkcja_sali = @IdFunkcja_sali, Poziom = @Poziom,
                //    Dostep_dla_niepelnosprawnych = @Dostep_dla_niepelnosprawnych, Uzytkownik = @Uzytkownik,
                //    Kolejnosc = @Kolejnosc, IdRozkladSali = @IdRozkladSali, LiczbaKomputerow = @LiczbaKomputerow,
                //    IdKomputer = @IdKomputer, Klimatyzacja = @Klimatyzacja
                //            Where IdSala = @IdSala;";
                //    connection.Execute(updateComputer, new { IdMonitor = c.IdMonitor, Procesor = c.Procesor, RAM = c.RAM, KartaGraficzna = c.KartaGraficzna, IdKomputer = c.IdKomputer });

                //    // SECOND: we delete all virtual machines that weren't chosen during the edit of the computer
                //    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteMaszynaWirtualnaKomputer_del stored procedure
                //    DataTable virtualMachines = new DataTable();
                //    virtualMachines.Columns.Add("IdMaszynaWirtualna", typeof(int));
                //    virtualMachines.Columns.Add("Nazwa", typeof(string));

                //    foreach (var item in c.VirtualMachines)
                //    {
                //        virtualMachines.Rows.Add(item.IdMaszynaWirtualna, item.Nazwa);
                //    }

                //    string deleteVirtualMachineComputer = @"EXEC dbo.zss_DeleteMaszynaWirtualnaKomputer_del @IdKomputer = @IdKomputer, @MaszynyWirtualne = @MaszynyWirtualne;";
                //    connection.Execute(deleteVirtualMachineComputer, new { IdKomputer = c.IdKomputer, MaszynyWirtualne = virtualMachines.AsTableValuedParameter("dbo.MaszynaWirtualnaType") });

                //    // THIRD: we delete all software that wasn't chosen during the edit of the computer
                //    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteOprogramowanieKomputerow_del stored procedure

                //    DataTable software = new DataTable();
                //    software.Columns.Add("IdOprogramowanie", typeof(int));
                //    software.Columns.Add("Nazwa", typeof(string));

                //    foreach (var item in c.Software)
                //    {
                //        software.Rows.Add(item.IdOprogramowanie, item.Nazwa);
                //    }

                //    string deleteComputerSoftware = @"EXEC dbo.zss_DeleteOprogramowanieKomputerow_del @IdKomputer = @IdKomputer, @Oprogramowanie = @Oprogramowanie";
                //    connection.Execute(deleteComputerSoftware, new { IdKomputer = c.IdKomputer, Oprogramowanie = software.AsTableValuedParameter("dbo.OprogramowanieType") });

                //    // FOURTH: We add missing virtual machines
                //    string addVirtualMachinesForComputer = @"IF NOT EXISTS( Select IdKomputer, IdMaszynaWirtualna
                //    FROM dbo.MaszynaWirtualnaKomputer
                //    WHERE IdKomputer = @IdKomputer AND IdMaszynaWirtualna = @IdMaszynaWirtualna)
                //    INSERT INTO dbo.MaszynaWirtualnaKomputer
                //    (IdKomputer, IdMaszynaWirtualna) 
                //    VALUES (@IdKomputer, @IdMaszynaWirtualna);";

                //    foreach (var item in c.VirtualMachines)
                //    {
                //        connection.Execute(addVirtualMachinesForComputer, new { IdKomputer = c.IdKomputer, IdMaszynaWirtualna = item.IdMaszynaWirtualna });
                //    }

                //    // FIFTH: We add missing software
                //    string addSoftwareForComputer = @"BEGIN IF NOT EXISTS( Select IdKomputer, IdOprogramowanie
                //    FROM dbo.OprogramowanieKomputerow
                //    WHERE IdKomputer = @IdKomputer AND IdOprogramowanie = @IdOprogramowanie)
                //    BEGIN
                //    INSERT INTO dbo.OprogramowanieKomputerow
                //    (IdKomputer, IdOprogramowanie) 
                //    VALUES (@IdKomputer, @IdOprogramowanie) END END;";

                //    foreach (var item in c.Software)
                //    {
                //        connection.Execute(addSoftwareForComputer, new { IdKomputer = c.IdKomputer, IdOprogramowanie = item.IdOprogramowanie });
                //    }
                //}
                //catch (InvalidOperationException e)
                //{
                //    Console.WriteLine(e.Message);
                //    connection.Close();
                //}
            }
        }

        public IEnumerable<EducationalClassroom> GetEducationalClassrooms()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_SalaDydaktycznaAll_sel;";
                try
                {
                    return connection.Query<EducationalClassroom>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public EducationalClassroom GetEducationalClassroom(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_SalaDydaktyczna_sel @IdSala = @IdSala;";
                try
                {
                    return connection.Query<EducationalClassroom>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }
        //TODO: create procedures instead of select statements (no *)
        public IEnumerable<VirtualMachineComputer> GetVirtualMachineComputers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"Select * From MaszynaWirtualnaKomputer;";
                try
                {
                    return connection.Query<VirtualMachineComputer>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public ComputerDetails GetComputerDetails(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string queryVirtualMachinesForComputer = @"EXEC dbo.zss_MaszynyWirtualneDlaKomputer_sel @IdKomputer = @IdKomputer;";
                const string queryComputer = @"EXEC dbo.zss_Komputer_sel @IdKomputer = @IdKomputer;";
                const string querySoftware = @"EXEC dbo.zss_OprogramowanieDlaKomputer_sel @IdKomputer = @IdKomputer;";
                try
                {
                    Computer c = connection.Query<Computer>(queryComputer, new { IdKomputer = id }).First();
                    ComputerDetails cd = new ComputerDetails
                    {
                        IdKomputer = c.IdKomputer,
                        IdMonitor = c.IdMonitor,
                        RozmiarMonitora = c.RozmiarMonitora,
                        Procesor = c.Procesor,
                        RAM = c.RAM,
                        KartaGraficzna = c.KartaGraficzna,
                        VirtualMachines = connection.Query<VirtualMachine>(queryVirtualMachinesForComputer, new { IdKomputer = id }),
                        Software = connection.Query<Software>(querySoftware, new { IdKomputer = id })
                    };
                    return cd;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }

        public void AddComputer(ComputerDetails c)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Queries
                    string addComputer = @"EXEC dbo.zss_AddKomputer_ins @IdMonitor = @IdMonitor, @Procesor = @Procesor,
                                        @RAM = @RAM, @KartaGraficzna = @KartaGraficzna;";

                    // TODO: procedures
                    string addVirtualMachinesForComputer = @"INSERT INTO dbo.MaszynaWirtualnaKomputer
                    (IdKomputer, IdMaszynaWirtualna) 
                    VALUES (@IdKomputer, @IdMaszynaWirtualna);";

                    string addSoftwareForComputer = @"INSERT INTO dbo.OprogramowanieKomputerow
                    (IdKomputer, IdOprogramowanie) 
                    VALUES (@IdKomputer, @IdOprogramowanie);";

                    // we need to get IdMonitor from the db because we get from FrontEnd just RozmiarMonitora, no IdMonitor.
                    //string getIdMonitor = @"Select IdMonitor From dbo.Monitor Where RozmiarMonitora = @RozmiarMonitora;";
                    //int idMonitor = connection.Query<Monitor>(getIdMonitor, new { RozmiarMonitora = c.RozmiarMonitora }).First().IdMonitor;

                    int idKomputer = connection.Query<Computer>(addComputer,
                        new
                        {
                            c.IdMonitor,
                            c.Procesor,
                            c.RAM,
                            c.KartaGraficzna
                        }).First().IdKomputer;

                    foreach (var item in c.VirtualMachines)
                    {
                        connection.Execute(addVirtualMachinesForComputer, new { IdKomputer = idKomputer, IdMaszynaWirtualna = item.IdMaszynaWirtualna });
                    }

                    foreach (var item in c.Software)
                    {
                        connection.Execute(addSoftwareForComputer, new { IdKomputer = idKomputer, IdOprogramowanie = item.IdOprogramowanie });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }
        }
        // TODO: finish Update
        public void EditComputer(ComputerDetails c)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // FIRST: update the computer
                    string updateComputer = @"Update dbo.Komputer set IdMonitor = @IdMonitor, Procesor = @Procesor, RAM = @RAM, KartaGraficzna = @KartaGraficzna
                            Where IdKomputer = @IdKomputer;";
                    connection.Execute(updateComputer, new { IdMonitor = c.IdMonitor, Procesor = c.Procesor, RAM = c.RAM, KartaGraficzna = c.KartaGraficzna, IdKomputer = c.IdKomputer });

                    // SECOND: we delete all virtual machines that weren't chosen during the edit of the computer
                    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteMaszynaWirtualnaKomputer_del stored procedure
                    DataTable virtualMachines = new DataTable();
                    virtualMachines.Columns.Add("IdMaszynaWirtualna", typeof(int));
                    virtualMachines.Columns.Add("Nazwa", typeof(string));

                    foreach (var item in c.VirtualMachines)
                    {
                        virtualMachines.Rows.Add(item.IdMaszynaWirtualna,item.Nazwa);
                    }
                    
                    string deleteVirtualMachineComputer = @"EXEC dbo.zss_DeleteMaszynaWirtualnaKomputer_del @IdKomputer = @IdKomputer, @MaszynyWirtualne = @MaszynyWirtualne;";
                    connection.Execute(deleteVirtualMachineComputer, new { IdKomputer = c.IdKomputer, MaszynyWirtualne = virtualMachines.AsTableValuedParameter("dbo.MaszynaWirtualnaType")});

                    // THIRD: we delete all software that wasn't chosen during the edit of the computer
                    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteOprogramowanieKomputerow_del stored procedure

                    DataTable software = new DataTable();
                    software.Columns.Add("IdOprogramowanie", typeof(int));
                    software.Columns.Add("Nazwa", typeof(string));

                    foreach (var item in c.Software)
                    {
                        software.Rows.Add(item.IdOprogramowanie, item.Nazwa);
                    }

                    string deleteComputerSoftware = @"EXEC dbo.zss_DeleteOprogramowanieKomputerow_del @IdKomputer = @IdKomputer, @Oprogramowanie = @Oprogramowanie";
                    connection.Execute(deleteComputerSoftware, new { IdKomputer = c.IdKomputer, Oprogramowanie = software.AsTableValuedParameter("dbo.OprogramowanieType")});

                    // FOURTH: We add missing virtual machines
                    string addVirtualMachinesForComputer = @"IF NOT EXISTS( Select IdKomputer, IdMaszynaWirtualna
                    FROM dbo.MaszynaWirtualnaKomputer
                    WHERE IdKomputer = @IdKomputer AND IdMaszynaWirtualna = @IdMaszynaWirtualna)
                    INSERT INTO dbo.MaszynaWirtualnaKomputer
                    (IdKomputer, IdMaszynaWirtualna) 
                    VALUES (@IdKomputer, @IdMaszynaWirtualna);";

                    foreach (var item in c.VirtualMachines)
                    {
                        connection.Execute(addVirtualMachinesForComputer, new { IdKomputer = c.IdKomputer, IdMaszynaWirtualna = item.IdMaszynaWirtualna });
                    }

                    // FIFTH: We add missing software
                    string addSoftwareForComputer = @"BEGIN IF NOT EXISTS( Select IdKomputer, IdOprogramowanie
                    FROM dbo.OprogramowanieKomputerow
                    WHERE IdKomputer = @IdKomputer AND IdOprogramowanie = @IdOprogramowanie)
                    BEGIN
                    INSERT INTO dbo.OprogramowanieKomputerow
                    (IdKomputer, IdOprogramowanie) 
                    VALUES (@IdKomputer, @IdOprogramowanie) END END;";

                    foreach (var item in c.Software)
                    {
                        connection.Execute(addSoftwareForComputer, new { IdKomputer = c.IdKomputer, IdOprogramowanie = item.IdOprogramowanie });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }
        }

        public IEnumerable<Floor> GetFloors()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC dbo.zss_Poziom_sel;;";
                try
                {
                    return connection.Query<Floor>(query);
                }
                // if the result is null then it throws InvalidOperationException
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return null;
                }
            }
        }
    }
}
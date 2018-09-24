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
using System.Threading.Tasks;
using Monitor = ClassroomManagementApi.Models.Monitor;

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

        public async Task<IEnumerable<Building>> GetBuildingsAsync()
        {
            IEnumerable<Building> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_BudynekAll_sel;";
                result = await connection.QueryAsync<Building>(query);
            }
            return result;
        }

        public async Task<Building> GetBuildingAsync(int id)
        {
            Building result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Budynek_sel @IdBudynek = @IdBudynek;";
                result = await connection.QuerySingleOrDefaultAsync<Building>(query, new { IdBudynek = id });
            }
            return result;
        }

        public async Task<IEnumerable<ClassroomFunction>> GetClassroomFunctionsAsync()
        {
            IEnumerable<ClassroomFunction> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_FunkcjaSaliAll_sel;";
                result = await connection.QueryAsync<ClassroomFunction>(query);
            }
            return result;
        }

        public async Task<ClassroomFunction> GetClassroomFunctionAsync(int id)
        {
            ClassroomFunction result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_FunkcjaSali_sel @IdFunkcja_sali = @IdFunkcja_sali;"; 
                // returns null if nothing was found
                result = await connection.QuerySingleOrDefaultAsync<ClassroomFunction>(query, new { IdFunkcja_sali = id });
            }
            return result;
        }

        public async Task<IEnumerable<Campus>> GetCampusAsync()
        {
            IEnumerable<Campus> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_KampusAll_sel;";
                result = await connection.QueryAsync<Campus>(query);
            }
            return result;
        }

        public async Task<Campus> GetCampusAsync(int id)
        {
            Campus result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Kampus_sel @IdKampus = @IdKampus;";
                result = await connection.QuerySingleOrDefaultAsync<Campus>(query, new { IdKampus = id });
            }
            return result;
        }

        public async Task<IEnumerable<VirtualMachine>> GetVirtualMachinesAsync()
        {
            IEnumerable<VirtualMachine> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_MaszynaWirtualnaAll_sel;";
                result = await connection.QueryAsync<VirtualMachine>(query);
            }
            return result;
        }

        public async Task<VirtualMachine> GetVirtualMachineAsync(int id)
        {
            VirtualMachine result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_MaszynaWirtualna_sel @IdMaszynaWirtualna = @IdMaszynaWirtualna;";
                result = await connection.QuerySingleOrDefaultAsync<VirtualMachine>(query, new { IdMaszynaWirtualna = id });
            }
            return result;
        }

        public async Task<IEnumerable<Monitor>> GetMonitorsAsync()
        {
            IEnumerable<Monitor> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_MonitorAll_Sel;";
                result = await connection.QueryAsync<Monitor>(query);
            }
            return result;
        }

        public async Task<Monitor> GetMonitorAsync(int id)
        {
            Monitor result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC zss_Monitor_sel @IdMonitor = @IdMonitor;";
                result = await connection.QuerySingleOrDefaultAsync<Monitor>(query, new { IdMonitor = id });
            }
            return result;
        }

        public async Task<IEnumerable<Software>> GetSoftwareAsync()
        {
            IEnumerable<Software> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_OprogramowanieAll_sel;";
                result = await connection.QueryAsync<Software>(query);
            }
            return result;
        }

        public async Task<Software> GetSoftwareAsync(int id)
        {
            Software result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Oprogramowanie_sel @IdOprogramowanie;";
                result = await connection.QuerySingleOrDefaultAsync<Software>(query, new { IdOprogramowanie = id });
            }
            return result;
        }

        public async Task<IEnumerable<ComputerSoftware>> GetComputerSoftwareAsync()
        {
            IEnumerable<ComputerSoftware> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC zss_OprogramowanieKomputerowAll_sel;";
                result = await connection.QueryAsync<ComputerSoftware>(query);
            }
            return result;
        } 

        public async Task<IEnumerable<Computer>> GetComputersAsync()
        {
            IEnumerable<Computer> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_KomputerAll_sel;";
                result = await connection.QueryAsync<Computer>(query);
            }
            return result;
        }

        public async Task<Computer> GetComputerAsync(int id)
        {
            Computer result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Komputer_sel @IdKomputer;";
                result = await connection.QuerySingleOrDefaultAsync<Computer>(query, new { IdKomputer = id });
            }
            return result;
        }

        public async Task<IEnumerable<ClassroomStructure>> GetClassroomStructuresAsync()
        {
            IEnumerable<ClassroomStructure> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC zss_RozkladSaliAll_sel;";
                result = await connection.QueryAsync<ClassroomStructure>(query);
            }
            return result;
        }

        public async Task<ClassroomStructure> GetClassroomStructureAsync(int id)
        {
            ClassroomStructure result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC zss_RozkladSali_sel @IdRozkladSali = @IdRozkladSali;";
                result = await connection.QuerySingleOrDefaultAsync<ClassroomStructure>(query, new { IdRozkladSali = id });
            }
            return result;
        }

        public async Task<IEnumerable<Classroom>> GetClassroomsAsync()
        {
            IEnumerable<Classroom> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_SalaAll_sel;";
                result = await connection.QueryAsync<Classroom>(query);
            }
            return result;
        }

        public async Task<IEnumerable<Classroom>> FilterClassroomsAsync(FilteringObject f)
        {
            IEnumerable<Classroom> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_FilterSala_sel @Budynki = @Buildings, @Klimatyzacja = @AirConditioning,
                @TV = @TV, @Projektor = @Projector, @TylkoSalaDydaktyczna = @OnlyEducationalClassrooms,
                @RozmiarSaliMin = @SizeMin, @RozmiarSaliMax = @SizeMax, @LiczbaMiejscMin = @PlacesMin, @LiczbaMiejscMax = @PlacesMax,
                @Dostep_dla_niepelnosprawnych = @AccessForTheDisabled, @FunkcjeSali = @ClassroomFunctions,
                @SearchCategory = @SearchCategory, @Search = @Search;";

                DataTable buildings = new DataTable();
                buildings.Columns.Add("IdBudynek", typeof(int));
                buildings.Columns.Add("Nazwa", typeof(string));

                if (f.Buildings != null)
                {
                    int id = 0;
                    foreach (var item in f.Buildings)
                    {
                        buildings.Rows.Add(id,item);
                        id++;
                    }
                }

                DataTable classroomFunctions = new DataTable();
                classroomFunctions.Columns.Add("IdFunkcjaSali", typeof(int));
                classroomFunctions.Columns.Add("Nazwa", typeof(string));

                if (f.ClassroomFunctions != null)
                {
                    int id = 0;
                    foreach (var item in f.ClassroomFunctions)
                    {
                        classroomFunctions.Rows.Add(id, item);
                        id++;
                    }
                }

                // we return EducationalClassrooms because we want to get additional data for Classrooms which are EducationalClassrooms
                result = await connection.QueryAsync<EducationalClassroom>(query,
                    new
                    {
                        Buildings = buildings.AsTableValuedParameter("dbo.BudynekTableType"),
                        f.AirConditioning,
                        f.TV,
                        f.Projector,
                        f.OnlyEducationalClassrooms,
                        f.SizeMin,
                        f.SizeMax,
                        f.PlacesMin,
                        f.PlacesMax,
                        f.AccessForTheDisabled,
                        ClassroomFunctions = classroomFunctions.AsTableValuedParameter("dbo.FunkcjaSaliTableType"),
                        f.SearchCategory,
                        f.Search
                    });
            }
            return result;
        }

        public async Task<Classroom> GetClassroomAsync(int id)
        {
            Classroom result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Sala_sel @IdSala = @IdSala;";
                result = await connection.QuerySingleOrDefaultAsync<Classroom>(query, new { IdSala = id });
            }
            return result;
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

                const string addSalaDydaktyczna = 
                    @"EXEC dbo.zss_Sala_dydaktyczna_ins 
                    @IdSala = @IdSala,
                    @Liczba_gniazd_sieciowych = @Liczba_gniazd_sieciowych,
                    @TV = @TV,
                    @Projektor = @Projektor,
                    @Liczba_miejsc_dydaktycznych = @Liczba_miejsc_dydaktycznych;";
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
                try
                {
                    // FIRST: update the computer
                    string updateClassroom =
                        @"EXEC dbo.zss_Sala_upd
						@Nazwa_sali = @Nazwa_sali,
						@Liczba_miejsc = @Liczba_miejsc,
						@Pow_m2 = @Pow_m2,
						@Uwagi = @Uwagi,
						@IdBudynek = @IdBudynek,
						@Istnieje = @Istnieje,
						@IdFunkcja_sali = @IdFunkcja_sali,
						@Poziom = @Poziom,
						@Dostep_dla_niepelnosprawnych = @Dostep_dla_niepelnosprawnych,
						@Uzytkownik = @Uzytkownik,
						@Kolejnosc = @Kolejnosc,
                        @IdRozkladSali = @IdRozkladSali,
						@LiczbaKomputerow = @LiczbaKomputerow,
						@IdKomputer = @IdKomputer,
                        @Klimatyzacja = @Klimatyzacja,
                        @IdSala = @IdSala";
                    connection.Execute(updateClassroom,
                        new {
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
                            c.Klimatyzacja,
                            c.IdSala
                        });

                    // check if c.CzyDydaktyczna = true
                    if(c.CzyDydaktyczna == true)
                    {
                        // update

                        string updateEducationalClassroom =
                            @"EXEC dbo.zss_Sala_dydaktyczna_upd 
                            @Liczba_gniazd_sieciowych = @Liczba_gniazd_sieciowych,
                            @TV = @TV,
                            @Projektor = @Projektor,
                            @Liczba_miejsc_dydaktycznych = @Liczba_miejsc_dydaktycznych,
                            @IdSala = @IdSala;";

                        connection.Execute(updateEducationalClassroom, new
                        {
                            c.Liczba_gniazd_sieciowych,
                            c.TV,
                            c.Projektor,
                            c.Liczba_miejsc_dydaktycznych,
                            c.IdSala
                        });
                    }
                    else
                    {
                        string deleteEducationalClassroom =
                            @"EXEC dbo.zss_Sala_dydaktyczna_del @IdSala = @IdSala;";

                        connection.Execute(deleteEducationalClassroom, new { c.IdSala });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }
        }

        public async Task<IEnumerable<EducationalClassroom>> GetEducationalClassroomsAsync()
        {
            IEnumerable<EducationalClassroom> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_SalaDydaktycznaAll_sel;";
                result = await connection.QueryAsync<EducationalClassroom>(query);
            }
            return result;
        }

        public async Task<EducationalClassroom> GetEducationalClassroomAsync(int id)
        {
            EducationalClassroom result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_SalaDydaktyczna_sel @IdSala = @IdSala;";
                result = await connection.QuerySingleOrDefaultAsync<EducationalClassroom>(query, new { IdSala = id });
            }
            return result;
        }
        //TODO: create procedures instead of select statements (no *)
        public async Task<IEnumerable<VirtualMachineComputer>> GetVirtualMachineComputersAsync()
        {
            IEnumerable<VirtualMachineComputer> result; 
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC zss_MaszynaWirtualnaKomputerAll_sel;";
                result = await connection.QueryAsync<VirtualMachineComputer>(query);
            }
            return result;
        }

        public async Task<ComputerDetails> GetComputerDetailsAsync(int id)
        {
            ComputerDetails result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string queryVirtualMachinesForComputer = @"EXEC dbo.zss_MaszynyWirtualneDlaKomputer_sel @IdKomputer = @IdKomputer;";
                const string queryComputer = @"EXEC dbo.zss_Komputer_sel @IdKomputer = @IdKomputer;";
                const string querySoftware = @"EXEC dbo.zss_OprogramowanieDlaKomputer_sel @IdKomputer = @IdKomputer;";
                Computer c = connection.Query<Computer>(queryComputer, new { IdKomputer = id }).First();
                ComputerDetails cd = new ComputerDetails
                {
                    IdKomputer = c.IdKomputer,
                    IdMonitor = c.IdMonitor,
                    RozmiarMonitora = c.RozmiarMonitora,
                    Procesor = c.Procesor,
                    RAM = c.RAM,
                    KartaGraficzna = c.KartaGraficzna,
                    VirtualMachines = await connection.QueryAsync<VirtualMachine>(queryVirtualMachinesForComputer, new { IdKomputer = id }),
                    Software = await connection.QueryAsync<Software>(querySoftware, new { IdKomputer = id })
                };
                return cd;
            }
        }

        public void AddComputerToClassroom(int idClassroom, int idComputer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string addComputerToClassroom = "EXEC dbo.zss_UpdateKomputerInSala_upd @IdKomputer = @IdKomputer, @IdSala = @IdSala;";
                connection.Execute(addComputerToClassroom, new { IdKomputer = idComputer, IdSala = idClassroom });
            }
        }

        public void AddComputer(ComputerDetails c, int? idSala)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Queries
                    string addComputer = @"EXEC dbo.zss_AddKomputer_ins @IdMonitor = @IdMonitor, @Procesor = @Procesor,
                                        @RAM = @RAM, @KartaGraficzna = @KartaGraficzna;";

                    // TODO: procedures
                    string addVirtualMachinesForComputer = @"EXEC zss_MaszynaWirtualnaKomputer_ins
                                                        @IdKomputer = @IdKomputer,
                                                        @IdMaszynaWirtualna = @IdMaszynaWirtualna;";

                    string addSoftwareForComputer = @"EXEC zss_OprogramowanieKomputerow_ins 
                                                    @IdKomputer = @IdKomputer,
                                                    @IdOprogramowanie = @IdOprogramowanie;";

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
                        connection.Execute(addVirtualMachinesForComputer, new { IdKomputer = idKomputer, item.IdMaszynaWirtualna });
                    }

                    foreach (var item in c.Software)
                    {
                        connection.Execute(addSoftwareForComputer, new { IdKomputer = idKomputer, item.IdOprogramowanie });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }
        }

        public void EditComputer(ComputerDetails c)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // FIRST: update the computer
                    string updateComputer =
                        @"EXEC dbo.zss_Komputer_upd 
                        @IdMonitor = @IdMonitor,
                        @Procesor = @Procesor,
                        @RAM = @RAM,
                        @KartaGraficzna = @KartaGraficzna,
                        @IdKomputer = @IdKomputer;";
                    connection.Execute(updateComputer, new { c.IdMonitor, c.Procesor, c.RAM, c.KartaGraficzna, c.IdKomputer });

                    // SECOND: we delete all virtual machines that weren't chosen during the edit of the computer
                    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteMaszynaWirtualnaKomputer_del stored procedure
                    DataTable virtualMachines = new DataTable();
                    virtualMachines.Columns.Add("IdMaszynaWirtualna", typeof(Int32));
                    virtualMachines.Columns.Add("Nazwa", typeof(string));

                    foreach (var item in c.VirtualMachines)
                    {
                        virtualMachines.Rows.Add(item.IdMaszynaWirtualna,item.Nazwa);
                    }
                    
                    string deleteVirtualMachineComputer = @"EXEC dbo.zss_DeleteMaszynaWirtualnaKomputer_del @IdKomputer = @IdKomputer, @MaszynyWirtualne = @MaszynyWirtualne;";
                    connection.Execute(deleteVirtualMachineComputer,
                        new { c.IdKomputer, MaszynyWirtualne = virtualMachines.AsTableValuedParameter("dbo.MaszynaWirtualnaTableType")});

                    // THIRD: we delete all software that wasn't chosen during the edit of the computer
                    // we create a temp table to use it later as a parameter for our dbo.zss_DeleteOprogramowanieKomputerow_del stored procedure

                    DataTable software = new DataTable();
                    software.Columns.Add("IdOprogramowanie", typeof(Int32));
                    software.Columns.Add("Nazwa", typeof(string));

                    foreach (var item in c.Software)
                    {
                        software.Rows.Add(item.IdOprogramowanie, item.Nazwa);
                    }

                    string deleteComputerSoftware = @"EXEC dbo.zss_DeleteOprogramowanieKomputerow_del @IdKomputer = @IdKomputer, @Oprogramowanie = @Oprogramowanie";
                    connection.Execute(deleteComputerSoftware, new { c.IdKomputer, Oprogramowanie = software.AsTableValuedParameter("dbo.OprogramowanieTableType")});

                    // FOURTH: We add missing virtual machines
                    string addVirtualMachineComputers = @"EXEC dbo.zss_MaszynaWirtualnaKomputer_ins
                                                        @IdKomputer = @IdKomputer,
                                                        @IdMaszynaWirtualna = @IdMaszynaWirtualna;";

                    foreach (var item in c.VirtualMachines)
                    {
                        connection.Execute(addVirtualMachineComputers, new { c.IdKomputer, item.IdMaszynaWirtualna });
                    }

                    // FIFTH: We add missing software
                    string addComputerSoftware = @"EXEC dbo.zss_OprogramowanieKomputerow_ins
                                                    @IdKomputer = @IdKomputer,
                                                    @IdOprogramowanie = @IdOprogramowanie;";

                    foreach (var item in c.Software)
                    {
                        connection.Execute(addComputerSoftware, new { c.IdKomputer, item.IdOprogramowanie });
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                }
            }
        }

        public async Task<IEnumerable<Floor>> GetFloorsAsync()
        {
            IEnumerable<Floor> result;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                const string query = @"EXEC dbo.zss_Poziom_sel;;";
                result = await connection.QueryAsync<Floor>(query);
            }
            return result;
        }
    }
}

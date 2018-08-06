using Dapper;
using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ZarzadzanieSalamiApi.Models
{
    public interface IZarzadzanieSalamiRepository
    {
        IEnumerable<Budynek> GetAllBudynek();
        Budynek GetBudynek(int id);
        IEnumerable<FunkcjaSali> GetAllFunkcjaSali();
        FunkcjaSali GetFunkcjaSali(int id);
        IEnumerable<Kampus> GetAllKampus();
        Kampus GetKampus(int id);
        IEnumerable<MaszynaWirtualna> GetAllMaszynaWirtualna();
        MaszynaWirtualna GetMaszynaWirtualna(int id);
        IEnumerable<Monitor> GetAllMonitor();
        Monitor GetMonitor(int id);
        IEnumerable<Oprogramowanie> GetAllOprogramowanie();
        Oprogramowanie GetOprogramowanie(int id);
        IEnumerable<OprogramowanieKomputerow> GetAllOprogramowanieKomputerow();
        IEnumerable<OprogramowanieKomputerow> GetOprogramowanieDlaKomputer(int id);
        IEnumerable<OprogramowanieKomputerow> GetKomputeryDlaOprogramowanie(int id);
        IEnumerable<Komputer> GetAllKomputer();
        Komputer GetKomputer(int id);
        IEnumerable<RozkladSali> GetAllRozkladSali();
        RozkladSali GetRozkladSali(int id);
        IEnumerable<Sala> GetAllSala();
        Sala GetSala(int id);
        void AddSala(Sala s);
        IEnumerable<SalaDydaktyczna> GetAllSalaDydaktyczna();
        SalaDydaktyczna GetSalaDydaktyczna(int id);


    }
    public class ZarzadzanieSalamiRepository : IZarzadzanieSalamiRepository
    {
        private readonly string connectionString;

        public ZarzadzanieSalamiRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Budynek> GetAllBudynek()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Budynek;";
                try
                {
                    return connection.Query<Budynek>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public Budynek GetBudynek(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Budynek_sel @IdBudynek = @IdBudynek;";
                try
                {
                    return connection.Query<Budynek>(query, new { IdBudynek = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        //TODO: No records in Kampus so I am not including Kampus column here
        public void AddBudynek(Budynek budynek)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO Budynek (Nazwa, IdMiasto, Adres_budynku, Opis, Istnieje) VALUES (@Nazwa, @IdMiasto, @Adres_budynku, @Opis, @Istnieje);";
                try
                {
                    connection.Execute(query,
                        new
                        {
                            budynek.Nazwa,
                            budynek.IdMiasto,
                            budynek.Adres_budynku,
                            budynek.Opis,
                            budynek.Istnieje,
                        });
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public IEnumerable<FunkcjaSali> GetAllFunkcjaSali()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Funkcja_sali;";
                try
                {
                    return connection.Query<FunkcjaSali>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public FunkcjaSali GetFunkcjaSali(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Funkcja_sali_sel @IdFunkcja_sali = @IdFunkcja_sali;";
                try
                {
                    return connection.Query<FunkcjaSali>(query, new { IdFunkcja_sali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<Kampus> GetAllKampus()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Kampus;";
                try
                {
                    return connection.Query<Kampus>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public Kampus GetKampus(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Kampus_sel @IdKampus = @IdKampus;";
                try
                {
                    return connection.Query<Kampus>(query, new { IdKampus = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<MaszynaWirtualna> GetAllMaszynaWirtualna()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna;";
                try
                {
                    return connection.Query<MaszynaWirtualna>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public MaszynaWirtualna GetMaszynaWirtualna(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM MaszynaWirtualna WHERE IdMaszynaWirtualna = @IdMaszynaWirtualna ;";
                try
                {
                    return connection.Query<MaszynaWirtualna>(query, new { IdMaszynaWirtualna = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<Monitor> GetAllMonitor()
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
                }
                return null;
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
                }
                return null;
            }
        }

        public IEnumerable<Oprogramowanie> GetAllOprogramowanie()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Oprogramowanie;";
                try
                {
                    return connection.Query<Oprogramowanie>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public Oprogramowanie GetOprogramowanie(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Oprogramowanie WHERE IdOprogramowanie = @IdOprogramowanie;";
                try
                {
                    return connection.Query<Oprogramowanie>(query, new { IdOprogramowanie = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<OprogramowanieKomputerow> GetAllOprogramowanieKomputerow()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow;";
                try
                {
                    return connection.Query<OprogramowanieKomputerow>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<OprogramowanieKomputerow> GetOprogramowanieDlaKomputer(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdKomputer = @IdKomputer;";
                try
                {
                    return connection.Query<OprogramowanieKomputerow>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<OprogramowanieKomputerow> GetKomputeryDlaOprogramowanie(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM OprogramowanieKomputerow WHERE IdOprogramowanie = @IdOprogramowanie;";
                try
                {
                    return connection.Query<OprogramowanieKomputerow>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<Komputer> GetAllKomputer()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Komputer;";
                try
                {
                    return connection.Query<Komputer>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public Komputer GetKomputer(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RodzajKomputerow WHERE IdRodzajKomputerow = @IdRodzajKomputerow;";
                try
                {
                    return connection.Query<Komputer>(query, new { IdKomputer = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<RozkladSali> GetAllRozkladSali()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali;";
                try
                {
                    return connection.Query<RozkladSali>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public RozkladSali GetRozkladSali(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM RozkladSali WHERE IdRozkladSali = @IdRozkladSali;";
                try
                {
                    return connection.Query<RozkladSali>(query, new { IdRozkladSali = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public IEnumerable<Sala> GetAllSala()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_SalaAll_sel;";
                try
                {
                    return connection.Query<Sala>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public Sala GetSala(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_Sala_sel @IdSala = @IdSala;";
                try
                {
                    return connection.Query<Sala>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public void AddSala(Sala s)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //TODO: query should be substituted with queryOld
                const string query = @"INSERT INTO Sala
                (Nazwa_sali, Liczba_miejsc, Pow_m2, Uwagi, IdBudynek, Istnieje, IdFunkcja_sali, Poziom, Dostep_dla_niepelnosprawnych, Uzytkownik, Kolejnosc, IdRozkladSali, LiczbaKomputerow, IdKomputer, Klimatyzacja) VALUES (@Nazwa_sali, @Liczba_miejsc, @Pow_m2, @Uwagi, @IdBudynek, @Istnieje, @IdFunkcja_sali, @Poziom, @Dostep_dla_niepelnosprawnych, @Uzytkownik, @Kolejnosc, @IdRozkladSali, @LiczbaKomputerow, @IdKomputer, @Klimatyzacja);";
                //TODO: delete queryOld
                const string queryOld = @"INSERT INTO Sala
                (Nazwa_sali, Liczba_miejsc, Pow_m2, Uwagi, IdBudynek, Istnieje, IdFunkcja_sali, Poziom, Dostep_dla_niepelnosprawnych, Uzytkownik, Kolejnosc) VALUES (@Nazwa_sali, @Liczba_miejsc, @Pow_m2, @Uwagi, @IdBudynek, @Istnieje, @IdFunkcja_sali, @Poziom, @Dostep_dla_niepelnosprawnych, @Uzytkownik, @Kolejnosc);";
                try
                {
                    connection.Execute(queryOld,
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
                            //s.IdRozkladSali,
                            //s.LiczbaKomputerow,
                            //s.IdKomputer,
                            //s.Klimatyzacja
                        });
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public IEnumerable<SalaDydaktyczna> GetAllSalaDydaktyczna()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT * FROM Sala_dydaktyczna;";
                try
                {
                    return connection.Query<SalaDydaktyczna>(query);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }

        public SalaDydaktyczna GetSalaDydaktyczna(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"EXEC zss_SalaDydaktyczna_sel @IdSala = @IdSala;";
                try
                {
                    return connection.Query<SalaDydaktyczna>(query, new { IdSala = id }).First();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
        }
    }
}

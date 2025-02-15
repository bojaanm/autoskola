using auto_skola.models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;  // Promjena za SQLite
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_skola.repositories
{
    public class kandidatRepository
    {
        // Konekcija za SQLite
        private readonly string connectionString = "Data Source=autoskola.db;Version=3;Journal Mode=Off;Cache Size=10000;";

        public kandidatRepository()
        {
            // Poziv funkcije za kreiranje tabele prilikom inicijalizacije
            CreateTable();
        }

        public void CreateTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS kandidati (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ime TEXT NOT NULL,
                        prezime TEXT NOT NULL,
                        broj_telefona TEXT,
                        broj_ljekarskog_uvjerenja TEXT,
                        broj_testova TEXT,
                        broj_prve_pomoci TEXT,
                        uplaceni_iznos TEXT
                    );";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Metode za rad sa kandidatima
        public List<kandidat> GetKandidats()
        {
            var kandidati = new List<kandidat>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM kandidati ORDER BY id DESC";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                kandidat kandidat = new kandidat
                                {
                                    id = reader.GetInt32(reader.GetOrdinal("id")),
                                    ime = reader.GetString(reader.GetOrdinal("ime")),
                                    prezime = reader.GetString(reader.GetOrdinal("prezime")),
                                    brTelefona = reader.GetString(reader.GetOrdinal("broj_telefona")),
                                    ljekarsko = reader.GetString(reader.GetOrdinal("broj_ljekarskog_uvjerenja")),
                                    testovi = reader.GetString(reader.GetOrdinal("broj_testova")),
                                    prvapomoc = reader.GetString(reader.GetOrdinal("broj_prve_pomoci")),
                                    uplata = reader.GetString(reader.GetOrdinal("uplaceni_iznos"))
                                };

                                kandidati.Add(kandidat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return kandidati;
        }

        public kandidat GetClient(int id)
        {
            kandidat kandidat = null;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM kandidati WHERE id = @id";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                kandidat = new kandidat
                                {
                                    id = reader.GetInt32(0),
                                    ime = reader.GetString(1),
                                    prezime = reader.GetString(2),
                                    brTelefona = reader.GetString(3),
                                    ljekarsko = reader.GetString(4),
                                    testovi = reader.GetString(5),
                                    prvapomoc = reader.GetString(6),
                                    uplata = reader.GetString(7)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return kandidat;
        }

        public void CreateKandidat(kandidat kandidat)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veza otvorena.");
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine("Greška pri otvaranju baze: " + ex.Message);
                }
                string query = "INSERT INTO kandidati (ime, prezime, broj_telefona, broj_ljekarskog_uvjerenja, broj_testova, broj_prve_pomoci, uplaceni_iznos) " +
                               "VALUES (@Ime, @Prezime, @BrojTelefona, @BrojLjekarskogUvjerenja, @BrojTestova, @BrojPrvePomoci, @UplaceniIznos)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ime", kandidat.ime);
                    command.Parameters.AddWithValue("@Prezime", kandidat.prezime);
                    command.Parameters.AddWithValue("@BrojTelefona", (object)kandidat.brTelefona ?? DBNull.Value);
                    command.Parameters.AddWithValue("@BrojLjekarskogUvjerenja", (object)kandidat.ljekarsko ?? DBNull.Value);
                    command.Parameters.AddWithValue("@BrojTestova", (object)kandidat.testovi ?? DBNull.Value);
                    command.Parameters.AddWithValue("@BrojPrvePomoci", (object)kandidat.prvapomoc ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UplaceniIznos", kandidat.uplata ?? "0.00");

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Podaci nisu spremljeni u bazu.");
                    }
                }
            }
        }

        public void UpdateKandidat(kandidat kandidat)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"UPDATE kandidati 
                          SET ime = @ime, 
                              prezime = @prezime, 
                              broj_telefona = @broj_telefona,
                              broj_ljekarskog_uvjerenja = @broj_ljekarskog_uvjerenja, 
                              broj_testova = @broj_testova, 
                              broj_prve_pomoci = @broj_prve_pomoci,
                              uplaceni_iznos = @uplaceni_iznos
                          WHERE id = @id"
                    ;

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", kandidat.id);
                        command.Parameters.AddWithValue("@ime", kandidat.ime);
                        command.Parameters.AddWithValue("@prezime", kandidat.prezime);
                        command.Parameters.AddWithValue("@broj_telefona", kandidat.brTelefona);
                        command.Parameters.AddWithValue("@broj_ljekarskog_uvjerenja", kandidat.ljekarsko);
                        command.Parameters.AddWithValue("@broj_testova", kandidat.testovi);
                        command.Parameters.AddWithValue("@broj_prve_pomoci", kandidat.prvapomoc);
                        command.Parameters.AddWithValue("@uplaceni_iznos", kandidat.uplata);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Kandidat uspješno ažuriran.");
                        }
                        else
                        {
                            Console.WriteLine("Nema kandidata sa datim ID-em.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void DeleteKandidat(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM kandidati WHERE id = @id";

                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Kandidat uspješno obrisan.");
                        }
                        else
                        {
                            Console.WriteLine("Nema kandidata sa datim ID-em.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void DropTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string dropTableQuery = "DROP TABLE IF EXISTS kandidati;"; // SQL komanda za brisanje tabele

                    using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tabela 'kandidati' je uspješno izbrisana.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom brisanja tabele: " + ex.Message);
                }
            }
        }

        public void DeleteAllRecords()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM kandidati;";

                    using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Svi podaci iz tabele 'kandidati' su obrisani.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom brisanja podataka: " + ex.Message);
                }
            }
        }

    }
}

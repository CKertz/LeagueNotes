using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueNotes
{
    public class DatabaseController
    {
        public NpgsqlConnection connectToDatabase()
        {
            //TODO: props file, plaintext password
            var connectionString = "Host=localhost;Username=postgres;Password=admin;Database=leaguenotes";

            var con = new NpgsqlConnection(connectionString);
            return con;

        }
        public void getAllEntries(NpgsqlConnection conn)
        {
            conn.Open();
            var sql = "SELECT * from entry";

            var cmd = new NpgsqlCommand(sql, conn);

            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", result.GetInt32(0), result.GetString(1),
                        result.GetString(2), result.GetString(3));
            }
            conn.Close();
        }
        public void createNewEntry(NpgsqlConnection conn)
        {
            conn.Open();
            var query = "INSERT INTO entry (a,b,c) VALUES ('','','')";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.ExecuteNonQuery();

        }
        protected void btnDbFetch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hi");
        }
    }
}

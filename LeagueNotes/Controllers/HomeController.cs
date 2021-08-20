using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeagueNotes.Models;
using Npgsql;

namespace LeagueNotes.Controllers
{
    public class HomeController : Controller
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=leaguenotes";
        NpgsqlConnection con = new NpgsqlConnection(connectionString);
        NpgsqlDataReader result;
        List<Entry> entries = new List<Entry>();

        private void GetTableData()
        {
            try
            {
                con.Open();
                var sql = "SELECT * from entry";
                var cmd = new NpgsqlCommand(sql, con);
                result = cmd.ExecuteReader();

                while (result.Read())
                {
                    entries.Add(new Entry() { entry_id = result["entry_id"].ToString(), match_history_link = result["match_history_link"].ToString(),
                        note_link= result["note_link"].ToString(), vod_link =result["vod_link"].ToString() });
                    Console.WriteLine("{0} {1} {2} {3}", result.GetInt32(0), result.GetString(1),
                            result.GetString(2), result.GetString(3));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Index()
        {
            GetTableData();
            return View(entries);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        protected void btnDbFetch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("hi");
        }

        public ActionResult YourAction()
        {
            //C# code here
            Console.WriteLine("hi");
            return View("About");
        }
    }
}

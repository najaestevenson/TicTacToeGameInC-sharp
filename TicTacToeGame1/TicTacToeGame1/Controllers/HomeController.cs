using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SQLite;

namespace TicTacToeGame1.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index(int id, string player)
        {
            TicTacToeGame1.Models.Class1 ttt = new TicTacToeGame1.Models.Class1();
            ViewBag.id = id;
            ViewBag.player = player;
            InsertIdIntoDb(id);
            ViewBag.allMoves = ttt.GetAllMovesFromDB(id);
            // UpdatePlayerMove(id,player,);
            return View();
            {

            }
        }
        public void InsertIdIntoDb(int id)
        {
            string connString = System.Configuration.ConfigurationManager.AppSettings["connString"];
            using (var conn = new SQLiteConnection(connString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "Insert or ignore into tictactoemoves (id) values ('" + id + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }
        public List<string> GetStateFromDB(int id)
        {
           List<string> allMoves = new List<string>();
            string connString = System.Configuration.ConfigurationManager.AppSettings["connString"];
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from tictactoemoves where id ='" + id + "'";
                    SQLiteDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        for (int i = 1; i <= 9; i++)
                            allMoves.Add(Convert.ToString(r["move" + i]));
                    }

                }
            }
            return allMoves;
        }

    }
}


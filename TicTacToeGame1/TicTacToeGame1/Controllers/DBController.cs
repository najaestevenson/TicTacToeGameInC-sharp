using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SQLite;

namespace TicTacToeGame1.Controllers
{
    public class DBController : ApiController
    {
        public class PlayerMove
        {
            public int id;
            public string player;
            public string move;


        }

        public string UpdatePlayerMove(PlayerMove pm)
        {
            string result = "";
            string[] moves = new string[] { "move1", "move2", "move3", "move4", "move5", "move6", "move7", "move8", "move9" };
            string[] players = new string[] { "X", "O" };
            int id = pm.id;
            string player = pm.player;
            string move = pm.move;
            TicTacToeGame1.Models.Class1 ttt = new TicTacToeGame1.Models.Class1();
            if (moves.Contains(move) && players.Contains(player))
            {
                if (String.IsNullOrEmpty(ttt.validateSpace(id, move)).Equals(true))
                {
                    string connString = System.Configuration.ConfigurationManager.AppSettings["connString"];
                    using (var conn = new SQLiteConnection(connString))
                    {

                        using (var cmd = conn.CreateCommand())
                        {
                            conn.Open();
                            cmd.CommandText = "Update tictactoemoves set '" + move + "'= '" + player + "'where id ='" + id + "'";
                            cmd.ExecuteNonQuery();

                        }
                        }
                    }
                 result = ttt.hasFoundWinner(id);
            }
                 return result;
        }

        public string GetNow()
        {
            return DateTime.Now.ToString();
        }

    }

}





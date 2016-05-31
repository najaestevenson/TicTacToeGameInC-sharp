using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TicTacToeGame1.Models
{
    public class Class1
    {   
         
             bool keepPlaying = true;
             string result = "";
        public string validateSpace(int id, string move)
        {
            string result;
            string connString = System.Configuration.ConfigurationManager.AppSettings["connString"];
            using (var conn = new SQLiteConnection(connString))
            {

                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "Select " + move + " FROM tictactoemoves where id ='" + id + "'";
                    result = cmd.ExecuteScalar().ToString();
                }
            } return result;
        }
         public List<string> GetAllMovesFromDB(int id)
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

         public string hasFoundWinner(int id)
         { List<string>allMoves = this.GetAllMovesFromDB(id);
            
             if (keepPlaying)
             {

                 if (allMoves[0] != "" && allMoves[0].Equals(allMoves[1]) && allMoves[1].Equals(allMoves[2]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[0] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[0];
                 }

                 if (allMoves[3] != "" && allMoves[3].Equals(allMoves[4]) && allMoves[4].Equals(allMoves[5]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[3] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[3];
                 }

                 if (allMoves[6] != "" && allMoves[6].Equals(allMoves[7]) && allMoves[7].Equals(allMoves[8]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[6] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[6];
                 }

                 if (allMoves[0] != "" && allMoves[0].Equals(allMoves[3]) && allMoves[3].Equals(allMoves[6]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[0] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[0];
                 }

                 if (allMoves[0] != "" && allMoves[0].Equals(allMoves[4]) && allMoves[4].Equals(allMoves[8]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[0] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[0];
                 }

                 if (allMoves[2] != "" && allMoves[2].Equals(allMoves[5]) && allMoves[5].Equals(allMoves[8]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[2] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[2];
                 }

                 if (allMoves[1] != "" && allMoves[1].Equals(allMoves[4]) && allMoves[4].Equals(allMoves[7]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[1] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[1];
                 }

                 if (allMoves[2] != "" && allMoves[2].Equals(allMoves[4]) && allMoves[4].Equals(allMoves[6]))
                 {
                     Console.WriteLine("\nCongrats " + allMoves[4] + " You win!");
                     keepPlaying = !keepPlaying;
                     result = allMoves[4];
                 }

                 if (allMoves.All(x=>x!=""))
                 {
                     Console.WriteLine("\nGame ended in a tie");
                     keepPlaying = !keepPlaying;
                     result = "Game Tied";
                 }
             }
            return result;
         }
         
         }
         }    
        
    



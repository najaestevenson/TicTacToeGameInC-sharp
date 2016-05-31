using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame1
{
    class TicTacToe
    {
        public string[,] board;
        string player1 = "X";
        string player2 = "O";
        static bool isPlayer1Turn = true;
        int counter = 0;
        bool keepPlaying = true;
        static List<string> playerMoves = new List<string>();


        public TicTacToe()
        {
            board = new string[3, 5] { { " ", "|", " ", "|", " " },
                                       { " ", "|", " ", "|", " " },
                                       { " ", "|", " ", "|", " " } };

        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(board[i, j]);
                }
                if (i < 2)
                    Console.WriteLine("\n-+-+-");
                else
                    Console.WriteLine();
            }
        }

        public void PlayGame()
        {
            DisplayBoard();
            while (counter <= 9 & keepPlaying)
            {
                if (isPlayer1Turn)
                {
                    Console.WriteLine("\nPlayer 1 go " + "Player 1 is " + player1);
                }
                else
                {
                    Console.WriteLine("\nPlayer 2 go  " + "Player 2 is " + player2);
                }
                MakeMove(Console.ReadLine());
                DisplayBoard();
            }
            gameOver();
        }

        public static void Main()
        {
            TicTacToe ttt = new TicTacToe();
            Console.WriteLine("Welcome to Tic Tac Toe." + "\n Please Make a move.\n");
            ttt.PlayGame();
            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }

        public bool ValidSpace(int a, int b)
        {
            if ((board[a, b] == "|" || board[a, b] == string.Empty) || (board[a, b].Equals("X") || board[a, b].Equals("O")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //returns Player's input and Player's mark ex.(2,0 X)
        public string MakeMove(string index)
        {
            string move = index;
            var position = index.Split(',');
            int a = Convert.ToInt32(position[0]);
            int b = Convert.ToInt32(position[1]);

            if (ValidSpace(a, b))
            {
                if (!isPlayer1Turn)
                {
                    board[a, b] = player2;
                }
                else 
                {
                    board[a, b] = player1;
                }
                counter++;
                isPlayer1Turn = !isPlayer1Turn;
                playerMoves.Add(move += board[a, b]);
                DetermineWinner();
                return move += board[a, b];
            }
            else
            {
                Console.WriteLine("Wrong selection. Please try again");
                PlayGame();
                return "";
            }
        }

        public void DetermineWinner()
        {
            string result = "";
            if (keepPlaying)
            {
                if (board[0, 0] != " " && board[0, 0].Equals(board[0, 2]) && board[0, 2].Equals(board[0, 4]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 0] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 0];
                }

                if (board[1, 0] != " " && board[1, 0].Equals(board[1, 2]) && board[1, 2].Equals(board[1, 4]))
                {
                    Console.WriteLine("\nCongrats " + this.board[1, 0] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[1, 0];
                }

                if (board[2, 0] != " " && board[2, 0].Equals(board[2, 2]) && board[2, 2].Equals(board[2, 4]))
                {
                    Console.WriteLine("\nCongrats " + this.board[2, 0] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[2, 0];
                }

                if (board[0, 0] != " " && board[0, 0].Equals(board[1, 0]) && board[1, 0].Equals(board[2, 0]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 0] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 0];
                }

                if (board[0, 2] != " " && board[0, 2].Equals(board[1, 2]) && board[1, 2].Equals(board[2, 2]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 2] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 2];
                }

                if (board[0, 4] != " " && board[0, 4].Equals(board[1, 4]) && board[1, 4].Equals(board[2, 4]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 4] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 4];
                }

                if (board[0, 0] != " " && board[0, 0].Equals(board[1, 2]) && board[1, 2].Equals(board[2, 4]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 0] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 0];
                }

                if (board[0, 4] != " " && board[0, 4].Equals(board[1, 2]) && board[1, 2].Equals(board[2, 0]))
                {
                    Console.WriteLine("\nCongrats " + this.board[0, 4] + " You win!");
                    keepPlaying = !keepPlaying;
                    result = this.board[0, 4];
                }

                if (counter == 9)
                {
                    Console.WriteLine("\nGame ended in a tie");
                    keepPlaying = !keepPlaying;
                    result = "Game Tied";
                }
            }
        }

        public void WriteToTextFile()
        {
            string path = @"c:\temp\TicTacToeGame.txt";
            if (this.keepPlaying == false)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string element in playerMoves)
                    {
                        sw.WriteLine(element);
                    }
                    if (isPlayer1Turn)
                    {
                        sw.WriteLine("\nThe Winner is " + player1);
                    }
                    else
                    {
                        sw.WriteLine("\n The Winner is " + player2);
                    }
                }
            }
        }

        public void gameOver()
        {
            WriteToTextFile();



        }
    }
}

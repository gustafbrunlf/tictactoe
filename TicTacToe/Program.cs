using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static string[] board = new String[10];
        static int choosennumber;
        static int player = 1;
        static int checkwinner;
        static bool playagain = true;
        static string answer;

        static void Main(string[] args)
        {
            Console.Title = ("Tic Tac Toe");
            while (playagain)
            {
                initialize();
                checkwinner = 0;

                while (checkwinner == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Spelare 1: X mot Spelare 2: O");
                    GameBoard();

                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Spelare 2 tur!");
                    }
                    else
                    {
                        Console.WriteLine("Spelare 1 tur!");
                    }

                    choosennumber = ReadNumber("Välj en position: ");

                    while (board[choosennumber] == "X" || board[choosennumber] == "O")
                    {
                        choosennumber = ReadNumber("Position är redan vald: ");
                    }

                    if (player % 2 == 0)
                    {
                        board[choosennumber] = "O";
                        player -= 1;
                    }
                    else
                    {
                        board[choosennumber] = "X";
                        player += 1;
                    }

                    checkwinner = CheckWin();

                    if (checkwinner == 1)
                    {
                        if (player % 2 == 0)
                        {
                            player = 1;
                        }
                        else
                        {
                            player = 2;
                        }
                        Console.Clear();
                        Console.WriteLine("Spelare 1: X mot Spelare 2: O");
                        GameBoard();
                        Console.WriteLine("Spelare {0} vann", player);
                        Console.WriteLine("Play again Y/N?");
                        answer = Console.ReadLine();

                        if (answer.ToUpper() == "Y")
                        {
                            playagain = true;
                        }
                        else
                        {
                            playagain = false;
                            Environment.Exit(0);
                        }
                    }
                    else if (checkwinner == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Spelare 1: X vs Spelare 2: O");
                        GameBoard();
                        Console.WriteLine("Lika!");
                        Console.WriteLine("Play again Y/N?");
                        answer = Console.ReadLine();

                        if (answer.ToUpper() == "Y")
                        {
                            playagain = true;
                        }
                        else
                        {
                            playagain = false;
                            Environment.Exit(0);
                        }
                    }

                }
            }
        }

        static void initialize() 
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void GameBoard()
        {
            for (int i = 1; i < 9; i+=3)
            {
                Console.WriteLine("   |   |   ");
                Console.WriteLine(" " + board[i] + " | " + board[i+1] + " | " + board[i+2]);
                Console.WriteLine("___|___|___");
            }
            //Console.WriteLine("   |   |   ");
            //Console.WriteLine(" {0} | {1} | {2} ", board[1], board[2], board[3]);
            //Console.WriteLine("___|___|___");
            //Console.WriteLine("   |   |   ");
            //Console.WriteLine(" {0} | {1} | {2} ", board[4], board[5], board[6]);
            //Console.WriteLine("___|___|___");
            //Console.WriteLine("   |   |   ");
            //Console.WriteLine(" {0} | {1} | {2} ", board[7], board[8], board[9]);
            //Console.WriteLine("   |   |   ");
        }

        static int CheckWin()
        {
            int win;

            if (board[1] == board[2] && board[2] == board[3])
            {
                win = 1;
            }
            else if (board[4] == board[5] && board[5] == board[6]) 
            {
                win = 1;
            }
            else if (board[7] == board[8] && board[8] == board[9])
            {
                win = 1;
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                win = 1;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                win = 1;
            }
            else if (board[3] == board[6] && board[6] == board[9])
            {
                win = 1;
            }
            else if (board[1] == board[5] && board[5] == board[9])
            {
                win = 1;
            }
            else if (board[3] == board[5] && board[5] == board[7])
            {
                win = 1;
            }
            else if (board[1] != "1" && board[2] != "2" && board[3] != "3" && board[4] != "4" && board[5] != "6" && board[7] != "7" && board[8] != "8" && board[9] != "9")
            {
                win = 2;
            }
            else
            {
                win = 0;
            }

            return win;
        }

        static int ReadNumber(string prompt)
        {
            var value = 0;
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out value))
                    return value;

                Console.WriteLine("Not a valid integer.");
            }
        }
    }
}

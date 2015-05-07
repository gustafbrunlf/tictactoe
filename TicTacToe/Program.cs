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
        static bool play = true;
        static string answer;
        static int row = 3;
        static int column = 3;

        static void Main(string[] args)
        {
            Console.Title = ("Tic Tac Toe");
            while (play)
            {
                InitializeValues();
                checkwinner = 0;

                while (checkwinner == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Spelare 1: X mot Spelare 2: O");
                    Gameboard();

                    if (player % 2 == 0)
                    {
                        Console.WriteLine("Spelare 2 tur!");
                    }
                    else
                    {
                        Console.WriteLine("Spelare 1 tur!");
                    }

                    try
                    {
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
                    }
                    catch (IndexOutOfRangeException)
                    {
                        choosennumber = ReadNumber("Positionerna är endast 1-9: ");
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
                        Result("Vinnaren är spelare ", player);
                        PlayAgain();
                    }
                    else if (checkwinner == 2)
                    {
                        Result("Lika!");
                        PlayAgain();
                    }
                }
            }
        }

        static void Result(string msg, int player = 0)
        {
            Console.Clear();
            Console.WriteLine("Spelare 1: X mot Spelare 2: O");
            Gameboard();
            if (player > 0)
            {
                Console.WriteLine(msg + player);
            }
            else
            {
                Console.WriteLine(msg);
            }
        }

        static void PlayAgain()
        {
            Console.WriteLine("Spela igen J/N?");
            answer = Console.ReadLine();

            if (answer.ToUpper() == "J")
            {
                play = true;
            }
            else
            {
                play = false;
                Environment.Exit(0);
            }
        }

        static void InitializeValues()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void Gameboard()
        {
            for(int i = 0; i < row; i++)
            {
                Console.WriteLine("   |   |   |");
                for(int j = 0; j < column; j++)
                {
                    var number = column * i + j + 1;
                    if (board[number] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (board[number] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(" " + board[number]);
                    Console.ResetColor();
                    Console.Write(" |");
                }
                Console.WriteLine();
                Console.WriteLine("___|___|___|");
            }
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
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Var vänlig skriv in en siffra.");
                }
            }
        }
    }
}

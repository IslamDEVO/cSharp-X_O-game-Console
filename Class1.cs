using System;

namespace X_O_game
{
    class game
    {
        

        struct player
        {
            public string name;
            public char ch;
            public int win;
            public int loss;
            public int[] cell;
        }

        public static void Draw (char[] arr)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0], arr[1], arr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[3], arr[4], arr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[6], arr[7], arr[8]);
            Console.WriteLine("     |     |      ");
        }

        public static sbyte ChekWin(char[] arr)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row   
            if (arr[0] == arr[1] && arr[1] == arr[2])
            {
                return 1;
            }
            //Winning Condition For Second Row   
            else if (arr[3] == arr[4] && arr[4] == arr[5])
            {
                return 1;
            }
            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (arr[0] == arr[3] && arr[3] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Second Column  
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Third Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[0] == arr[4] && arr[4] == arr[8])
            {
                return 1;
            }
            else if (arr[2] == arr[4] && arr[4] == arr[6])
            {
                return 1;
            }
            #endregion

            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[0] != '1' && arr[1] != '2' && arr[2] != '3' && arr[3] != '4' && arr[4] != '5' && arr[5] != '6' && arr[6] != '7' && arr[7] != '8' && arr[8] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        
    }

        static void Main(string[] args)
        {

            #region Basic code

            player p1, p2;
            p1.loss = 0;    p1.win = 0;
            p2.loss = 0;    p2.win = 0;
            Console.WriteLine("\n player 1 enter your name \t");
            p1.name = Console.ReadLine();
            Console.WriteLine("\n {0} chose X or O \t", p1.name);
            char chek;
            do
            {
                chek = Console.ReadKey().KeyChar;
                if (chek == 'X' || chek == 'x')
                {
                    p1.ch = 'X';
                    p1.cell = new int[5];
                    p2.ch = 'O';
                    p2.cell = new int[5];
                    break;
                }
                else if (chek == 'O' || chek == 'o')
                {
                    p1.ch = 'O';
                    p1.cell = new int[5];
                    p2.ch = 'X';
                    p2.cell = new int[5];
                    break;
                }

                Console.WriteLine("\n chose correct from X or O ");
            } while (true);

            Console.WriteLine("\n you want to play whit another player enter Y or N ");
            char chekPlayer = Console.ReadKey().KeyChar;

            #endregion

            if (chekPlayer == 'y' || chekPlayer == 'Y')
            {

                #region Player to Player
                Console.WriteLine("\n player 2 enter your name \t");
                p2.name = Console.ReadLine();
                do
                {
                    char[] mat = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    ////////////////////////////////////////////////////////////////////////
                    //int currentLineCursor = Console.CursorTop;
                    //Console.SetCursorPosition(0, Console.CursorTop);
                    //Console.Write(new string(' ', Console.WindowWidth));
                    //Console.SetCursorPosition(0, currentLineCursor);
                    ///////////////////////////////////////////////////////////////////////////
                    Draw(mat);

                    char chekNum;
                    byte p1Index = 0, p2Index = 0;
                    sbyte winner;


                    do
                    {
                        Console.WriteLine("{0} enter your position to write {1}", p1.name, p1.ch);
                        chekNum = Console.ReadKey().KeyChar;
                        //test
                        //Console.WriteLine("\n" + Convert.ToInt32(chekNum));
                        do
                        {
                            if (Convert.ToInt32(chekNum) >= 49 && Convert.ToInt32(chekNum) <= 57)
                            {
                                if (mat[Convert.ToInt32(chekNum) - 49] != 'X' && mat[Convert.ToInt32(chekNum) - 49] != 'O')
                                {
                                    mat[Convert.ToInt32(chekNum) - 49] = p1.ch;
                                    p1.cell[p1Index++] = Convert.ToInt32(chekNum) - 48;
                                    break;
                                }
                                Console.WriteLine("\n this position is occupied enter again");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                            else
                            {
                                Console.WriteLine("\n enter position from 1 to 9 ");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                        } while (true);
                        Draw(mat);
                        winner = ChekWin(mat);
                        if (winner == 1)
                        {
                            Console.WriteLine("\n {0} is the winner ", p1.name);
                            p1.win++;
                            p2.loss--;
                            break;
                        }
                        else if (winner == -1)
                        {
                            Console.WriteLine("\n no winner ");
                            break;
                        }


                        //////////////// player two
                        Console.WriteLine("{0} enter your position to write {1}", p2.name, p2.ch);
                        chekNum = Console.ReadKey().KeyChar;
                        //test
                        //Console.WriteLine("\n" + Convert.ToInt32(chekNum));
                        do
                        {
                            if (Convert.ToInt32(chekNum) >= 49 && Convert.ToInt32(chekNum) <= 57)
                            {
                                if (mat[Convert.ToInt32(chekNum) - 49] != 'X' && mat[Convert.ToInt32(chekNum) - 49] != 'O')
                                {
                                    mat[Convert.ToInt32(chekNum) - 49] = p2.ch;
                                    p2.cell[p2Index++] = Convert.ToInt32(chekNum) - 48;
                                    break;
                                }
                                Console.WriteLine("\n this position is occupied enter again");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                            else
                            {
                                Console.WriteLine("\n enter position from 1 to 9 ");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                        } while (true);
                        Draw(mat);
                        winner = ChekWin(mat);
                        if (winner == 1)
                        {
                            Console.WriteLine("\n {0} is the winner ", p2.name);
                            p2.win++;
                            p1.loss--;
                            break;
                        }
                        else if (winner == -1)
                        {
                            Console.WriteLine("\n no winner ");
                            break;
                        }

                    } while (true);

                    Console.WriteLine("\n the result is \n player 1 {0} win : {1} \t loss : {2}", p1.name, p1.win, p1.loss);
                    Console.WriteLine("\n player 2 {0} win : {1} \t loss : {2}", p2.name, p2.win, p2.loss);

                    Console.WriteLine("\n do want play again Y or N \n ");
                    char again = Console.ReadKey().KeyChar;
                    //test
                    //Console.WriteLine(again);
                    if (again != 'y' && again != 'Y')
                    {
                        break;
                    }
                    //Console.Clear();

                } while (true);

                #endregion
            }

            #region Player to Computer

            else if (chekPlayer == 'n' || chekPlayer == 'N')
            {
                
                //Console.WriteLine("\n player 2 enter your name \t");
                p2.name = "Computer";
                do
                {
                    char[] mat = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    ////////////////////////////////////////////////////////////////////////
                    //int currentLineCursor = Console.CursorTop;
                    //Console.SetCursorPosition(0, Console.CursorTop);
                    //Console.Write(new string(' ', Console.WindowWidth));
                    //Console.SetCursorPosition(0, currentLineCursor);
                    ///////////////////////////////////////////////////////////////////////////
                    Draw(mat);

                    char chekNum;
                    byte p1Index = 0, p2Index = 0;
                    sbyte winner;


                    do
                    {
                        Console.WriteLine("{0} enter your position to write {1}", p1.name, p1.ch);
                        chekNum = Console.ReadKey().KeyChar;
                        //test
                        //Console.WriteLine("\n" + Convert.ToInt32(chekNum));
                        do
                        {
                            if (Convert.ToInt32(chekNum) >= 49 && Convert.ToInt32(chekNum) <= 57)
                            {
                                if (mat[Convert.ToInt32(chekNum) - 49] != 'X' && mat[Convert.ToInt32(chekNum) - 49] != 'O')
                                {
                                    mat[Convert.ToInt32(chekNum) - 49] = p1.ch;
                                    p1.cell[p1Index++] = Convert.ToInt32(chekNum) - 48;
                                    break;
                                }
                                Console.WriteLine("\n this position is occupied enter again");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                            else
                            {
                                Console.WriteLine("\n enter position from 1 to 9 ");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                        } while (true);
                        Draw(mat);
                        winner = ChekWin(mat);
                        if (winner == 1)
                        {
                            Console.WriteLine("\n {0} is the winner ", p1.name);
                            p1.win++;
                            p2.loss--;
                            break;
                        }
                        else if (winner == -1)
                        {
                            Console.WriteLine("\n no winner ");
                            break;
                        }


                        //////////////// player two
                        //Console.WriteLine("{0} enter your position to write {1}", p2.name, p2.ch);
                        //chekNum = Console.ReadKey().KeyChar;

                        Random rand=new Random();
                        //test
                        //Console.WriteLine(rand);
                        chekNum = Convert.ToChar(rand.Next(8) + 49);
                        //test
                        //Console.WriteLine(chekNum);
                        //test
                        //Console.WriteLine("\n" + Convert.ToInt32(chekNum));
                        do
                        {
                            if (Convert.ToInt32(chekNum) >= 49 && Convert.ToInt32(chekNum) <= 57)
                            {
                                if (mat[Convert.ToInt32(chekNum) - 49] != 'X' && mat[Convert.ToInt32(chekNum) - 49] != 'O')
                                {
                                    mat[Convert.ToInt32(chekNum) - 49] = p2.ch;
                                    p2.cell[p2Index++] = Convert.ToInt32(chekNum) - 48;
                                    break;
                                }
                                //Console.WriteLine("\n this position is occupied enter again");
                                //chekNum = Console.ReadKey().KeyChar;
                                Console.WriteLine(rand);
                                chekNum = Convert.ToChar(rand.Next(8) + 49);
                            }
                            else
                            {
                                Console.WriteLine("\n enter position from 1 to 9 ");
                                chekNum = Console.ReadKey().KeyChar;
                            }
                        } while (true);
                        Draw(mat);
                        winner = ChekWin(mat);
                        if (winner == 1)
                        {
                            Console.WriteLine("\n {0} is the winner ", p2.name);
                            p2.win++;
                            p1.loss--;
                            break;
                        }
                        else if (winner == -1)
                        {
                            Console.WriteLine("\n no winner ");
                            break;
                        }

                    } while (true);

                    Console.WriteLine("\n the result is \n player 1 {0} win : {1} \t loss : {2}", p1.name, p1.win, p1.loss);
                    Console.WriteLine("\n player 2 {0} win : {1} \t loss : {2}", p2.name, p2.win, p2.loss);

                
                    Console.WriteLine("\n do want play again Y or N \n ");
                    char again = Console.ReadKey().KeyChar;
                    //test
                    //Console.WriteLine(again);
                    if (again != 'y' && again != 'Y')
                    {
                        break;
                    }
                    //Console.Clear();

                } while (true);

            }


            #endregion
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{
    class MazeGen
    {
        public  string[,] mazeLayout;
        private  List<Stem> allStems = new List<Stem>();
        private  List<Stem> aliveStems = new List<Stem>();
        private  List<Stem> tempStems = new List<Stem>();
        private  int Rows;
        private  int Cols;
        private  int reviveChance = 15; // 10%
        public static string wall = "1";
        public static string path = "0";
       private   Random rand = new Random();
        public  void CreateMaze(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            
            mazeLayout = new string[rows, cols];
            //Creates board
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    mazeLayout[i, j] = wall;
                }
            }
            allStems.Add(new Stem(0, 0));
            aliveStems.Add(new Stem(0, 0));

            // mazeLayout[currentY, currentX] = "5";
            // mazeLayout[rows - 2, cols - 1] = "9";

            //Number of times to run
            for (int i = 0; i < (1900); i++)
            {
                AddStem();
                tempStems.Clear();
                ReviveStems();
            }


            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write(string.Format("{0}", mazeLayout[i, j]));
            //    }
            //    Console.Write(Environment.NewLine);
            //}
            //Console.WriteLine("-------------------------------------------------");
        }

        private  bool ValidateMove(int Y, int X)
        {
            if (mazeLayout[Y, X] == path)
            {
                return false;
            }
            if (X - 1 >= 0 && X + 1 < Cols)
            {
                //normal case
                if (mazeLayout[Y, X - 1] == path || mazeLayout[Y, X + 1] == path)
                {
                    return false;
                }

            }
            else
            {
                //edge case

                if (Y - 1 >= 0)
                {
                    if (mazeLayout[Y - 1, X] == path)
                    {
                        return false;
                    }
                }
                if (Y + 1 < Rows)
                {
                    if (mazeLayout[Y + 1, X] == path)
                    {
                        return false;
                    }
                }
                if (X - 1 >= 0)
                {
                    //normal case
                    if (mazeLayout[Y, X - 1] == path)
                    {
                        return false;
                    }
                }
                if ( X + 1 < Cols)
                {
                    //normal case
                    if (mazeLayout[Y, X + 1] == path)
                    {
                        return false;
                    }

                }
            }

            if (Y - 1 >= 0 && Y + 1 < Rows)
            {
                //normal case
                if (mazeLayout[Y-1, X] == path || mazeLayout[Y+1, X] == path)
                {
                    return false;
                }
            
            }
            else
            {
                //edge case
             
                if (X - 1 >= 0)
                {
                    if (mazeLayout[Y, X-1] == path)
                    {
                        return false;
                    }
                }
                if (X + 1 <= Rows - 1)
                {
                    if (mazeLayout[Y, X+1] == path)
                    {
                        return false;
                    }
                }
                if (Y - 1 >= 0)
                {
                    //normal case
                    if (mazeLayout[Y - 1, X] == path)
                    {
                        return false;
                    }

                }
                if ( Y + 1 < Rows)
                {
                    //normal case
                    if (mazeLayout[Y + 1, X] == path)
                    {
                        return false;
                    }

                }
            }
            return true;
       }

        private  void AddStem()
        {
            foreach (var stem in aliveStems)
            {
                int num = rand.Next(0, 4);
                int X = stem.x;
                int Y = stem.y;
                //0 left, 1 up, 2 right, 3 down

                //LEFT
                if (num == 0 && X > 0)
                {
                    X--;
                    mazeLayout[Y, X + 1] = wall; // needed so validation doesn't always fail
                    if (ValidateMove(Y, X))
                    {
                        mazeLayout[Y, X] = path;
                        allStems.Add(new Stem(Y, X));
                        tempStems.Add(new Stem(Y, X));
                    }
                  

                    mazeLayout[Y, X + 1] = path; // set back to its original state

                }
                //UP
                if (num == 1 && Y > 0)
                {
                    Y--;
                    mazeLayout[Y + 1, X] = wall; // needed so validation doesn't always fail
                    if (ValidateMove(Y, X))
                    {
                        mazeLayout[Y, X] = path;
                        allStems.Add(new Stem(Y, X));
                        tempStems.Add(new Stem(Y, X));
                    }

                    mazeLayout[Y + 1, X] = path; //  set back to its original state


                }
                //RIGHT
                if (num == 2 && X < Cols - 1)
                {
                    X++;
                    mazeLayout[Y, X - 1] = wall; // needed so validation doesn't always fail
                    if (ValidateMove(Y, X))
                    {
                        mazeLayout[Y, X] = path;
                        allStems.Add(new Stem(Y, X));
                        tempStems.Add(new Stem(Y, X));
                    }

                    mazeLayout[Y, X - 1] = path; // set back to its original state

                }
                //DOWN
                if (num == 3 && Y < Rows - 1)
                {
                    Y++;
                    mazeLayout[Y - 1, X] = wall; // needed so validation doesn't always fail
                    if (ValidateMove(Y, X))
                    {
                        mazeLayout[Y, X] = path;
                        allStems.Add(new Stem(Y, X));
                        tempStems.Add(new Stem(Y, X));

                    }
                    else
                    {
                       
                    }

                    mazeLayout[Y - 1, X] = path; // set back to its original state
                }

            }
            aliveStems = tempStems.ToList();
        }

        private  void ReviveStems()
        {
            foreach (var stem in allStems)
            {
                int chance = rand.Next(1,101); // 1 - 100
                if (chance < reviveChance)
                {
                    if (!aliveStems.Contains(stem))
                    {
                        aliveStems.Add(stem);
                    }
                }
            }
        }

    }

    class Stem
    {
        public Stem(int Y, int X)
        {
            y = Y;
            x = X;
        }
        public int y { get; set; }
        public int x { get; set; }
        public bool IsAlive { get; set; }
      
    }

}

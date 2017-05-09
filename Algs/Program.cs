using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{

    class Program
    {
        // static node final;

        static int walls = 1; // Frequency of a wall
        static int h = 15;
        static int c = 15;
        public static string[,] layout = new string[h, c];
        public static string[,] hiddenLayout = new string[h, c];
        public static int rowLength = layout.GetLength(0);
        public static int colLength = layout.GetLength(1);
        public static Random rand = new Random();
        public static node finalNode;

        static void Main()
        {
            MazeGen.CreateMaze(h, c);
            layout = MazeGen.mazeLayout;
            //builds the random layout
            CreateBoard();

            node master = new node(0, 0, 0, null);

            master.nodelist.Add(new node(1, 1, 0, master));
            master.nodelist.Add(new node(1, 0, 1, master));
            // BreadthFirst.addNode(master);
            BreadthFirst.addNode(master);
            node highest = new node(1000, 0, 0, null);

            RollOut(finalNode);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", layout[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.Write(finalNode.steps);
            Console.ReadLine();


        }
        static int i = 2;
        static void RollOut(node t)
        {

            try
            {
                if (i > 9)
                {
                    i = 2;
                }
                layout[t.Y, t.X] = "*";
                RollOut(t.previous);
            }
            catch (Exception)
            {


            }

        }
        static void CreateBoard()
        {

            //for (int r = 0; r < rowLength; r++)
            //{
            //    for (int c = 0; c < colLength; c++)
            //    {
            //        hiddenLayout[r, c] = "0";
            //        int randInt = rand.Next(10);
            //        if (randInt < walls)
            //        {
            //            layout[r, c] = "1";
            //        }
            //        else
            //        {
            //            layout[r, c] = "0";
            //        }
            //    }
            //}
            layout[rowLength - 1, colLength - 1] = "9";
            layout[0, 0] = "0";

        }
        static bool temp = false;
        static bool HasOverflow(node t, int x, int y)
        {
            try
            {
                if (t.previous == null)
                {
                    return false;
                }
                else if (t.previous.X == x && t.previous.Y == y)
                {
                    temp = true;
                }

                HasOverflow(t.previous, x, y);
            }
            catch (Exception)
            {


            }
            return temp;

        }

    }

}



class node
{
    public int X, Y, steps;
    public List<node> nodelist = new List<node>();
    public node previous;
    public node(int st, int y, int x, node p)
    {
        Y = y;
        X = x;
        previous = p;
        steps = st;
    }
}
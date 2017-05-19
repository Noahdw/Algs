using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algs
{

    class Program
    {
        // static node final;

        static int walls = 1; // Frequency of a wall
        
        public static int runs = 0;
        static int c = 100;
        static int h = 100;

        public static string[,] layout = new string[h, c];
        public static string[,] hiddenLayout;
        public static int rowLength = layout.GetLength(0);
        public static int colLength = layout.GetLength(1);
        public static Random rand = new Random();
        public static Node finalNode;
        private static int highest = 0;
        static void Main()
        {
           
            while (true)
            {
                hiddenLayout = new string [ h, c ];
                MazeGen maze = new MazeGen();
                BreadthFirst breadth = new BreadthFirst();
                DepthFirst depth = new DepthFirst();
                SpiralGen spiral = new SpiralGen();
                spiral.CreateSpiral(1000,1000);
                maze.CreateMaze(h, c);
                layout = maze.mazeLayout;

                CreateBoard(); // usless, just sets maze goal
                Node master = new Node(0, 0, 0, null);

                master.nodelist.Add(new Node(1, 1, 0, master));
                master.nodelist.Add(new Node(1, 0, 1, master));
                // BreadthFirst.BeginSearch(master);
                breadth.BeginSearch(master);
               // BreadthFirst.done = false;
                highest = finalNode.steps;

                RollOut(finalNode);

                //for (int i = 0; i < rowLength; i++)
                //{
                //    for (int j = 0; j < colLength; j++)
                //    {

                //        Console.Write(string.Format("{0}", layout[i, j]));

                //    }
                //    Console.Write(Environment.NewLine);
                //}
                ImageHelper image = new ImageHelper();
                image.CreateImage(layout,20,"maze");
                runs++;
            }
           

        
            RollOut(finalNode);
           
            //for (int i = 0; i < rowLength; i++)
            //{
            //    for (int j = 0; j < colLength; j++)
            //    {
                   
            //        Console.Write(string.Format("{0}", layout[i, j]));
                    
            //    }
            //    Console.Write(Environment.NewLine);
            //}
            
            Console.Write(highest);
      

            Console.ReadLine();


        }

        static void RollOut(Node t)
        {

            try
            {
               
                layout[t.Y, t.X] = "2";
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
   

    }

}



class Node
{
    public int X, Y, steps;
    public List<Node> nodelist = new List<Node>();
    public Node previous;
    public Node(int st, int y, int x, Node p)
    {
        Y = y;
        X = x;
        previous = p;
        steps = st;
    }
}
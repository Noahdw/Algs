using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{
    class BreadthFirst
    {
        private  bool done = false;
        public  Node BeginSearch(Node mList)
        {

            Node loopNode = new Node(0, 0, 0, null);
            List<Node> tList = new List<Node>();
            foreach (Node item in mList.nodelist)
            {

                int x = item.X;
                int y = item.Y;

                if (done == true)
                {
                    //  layout[mList.Y, mList.X] = 5;
                    return item;
                }


                if (Program.layout[y, x] == "9")
                {
                    System.Diagnostics.Debug.WriteLine("found 9 with " + item.steps + " steps.");

                    tList.Add(new Node(item.steps + 1, y, x, item));
                    item.nodelist = tList;

                    Program.finalNode = item;
                    mList.nodelist.Remove(item);

                    done = true;


                    break;

                }

                //if (hasOverflow(item, x, y))
                //{
                //    System.Diagnostics.Debug.WriteLine("found repeat");
                //    temp = false;
                //    mList.nodelist.Remove(item);
                //    break;
                //}

                if (x + 1 < Program.layout.GetLength(1))
                {
                    if ((Program.layout[y, x + 1] != MazeGen.wall) && (Program.hiddenLayout[y, x + 1] != MazeGen.wall))
                    {
                        Program.hiddenLayout[y, x + 1] = MazeGen.wall;
                        tList.Add(new Node(item.steps + 1, y, x + 1, item));


                    }

                }
                if (x - 1 >= 0)
                {

                    if ((Program.layout[y, x - 1] != MazeGen.wall) && (Program.hiddenLayout[y, x - 1] != MazeGen.wall))
                    {
                        Program.hiddenLayout[y, x - 1] = MazeGen.wall;
                        tList.Add(new Node(item.steps + 1, y, x - 1, item));


                    }
                }
                if (y + 1 < Program.layout.GetLength(0))
                {

                    if ((Program.layout[y + 1, x] != MazeGen.wall) && (Program.hiddenLayout[y + 1, x] != MazeGen.wall))
                    {
                        Program.hiddenLayout[y + 1, x] = MazeGen.wall;
                        tList.Add(new Node(item.steps + 1, y + 1, x, item));


                    }
                }
                if (y - 1 >= 0)
                {
                    if ((Program.layout[y - 1, x] != MazeGen.wall) && (Program.hiddenLayout[y - 1, x] != MazeGen.wall))
                    {


                        Program.hiddenLayout[y - 1, x] = MazeGen.wall;
                        tList.Add(new Node(item.steps + 1, y - 1, x, item));


                    }
                }
                item.nodelist = tList;




            }
            loopNode.nodelist = tList;
            BeginSearch(loopNode);


            return null;
        }
    }
}

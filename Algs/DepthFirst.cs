
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{
    class DepthFirst
    {
        static bool done = false;
        public static node addNode(node mList)
        {

            foreach (node item in mList.nodelist)
            {
                List<node> tList = new List<node>();
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

                    tList.Add(new node(item.steps + 1, y, x, item));
                    item.nodelist = tList;

                    Program.finalNode = item;
                    //final = item;
                    mList.nodelist.Remove(item);
                    done = true;

                    break;

                }



                if (x + 1 < Program.layout.GetLength(1))
                {
                    if ((Program.layout[y, x + 1] != "1") && (Program.hiddenLayout[y, x + 1] != "1"))
                    {

                        Program.hiddenLayout[y, x + 1] = "1";
                        tList.Add(new node(item.steps + 1, y, x + 1, item));


                    }

                }
                if (x - 1 >= 0)
                {

                    if ((Program.layout[y, x - 1] != "1") && (Program.hiddenLayout[y, x - 1] != "1"))
                    {

                        Program.hiddenLayout[y, x - 1] = "1";
                        tList.Add(new node(item.steps + 1, y, x - 1, item));


                    }
                }
                if (y + 1 < Program.layout.GetLength(0))
                {

                    if ((Program.layout[y + 1, x] != "1") && (Program.hiddenLayout[y + 1, x] != "1"))
                    {

                        Program.hiddenLayout[y + 1, x] = "1";
                        tList.Add(new node(item.steps + 1, y + 1, x, item));


                    }
                }
                if (y - 1 >= 0)
                {
                    if ((Program.layout[y - 1, x] != "1") && (Program.hiddenLayout[y - 1, x] != "1"))
                    {

                        Program.hiddenLayout[y - 1, x] = "1";
                        tList.Add(new node(item.steps + 1, y - 1, x, item));


                    }
                }
                item.nodelist = tList;
                if (!done)
                {

                }
                addNode(item);


            }


            return null;
        }
    }

}
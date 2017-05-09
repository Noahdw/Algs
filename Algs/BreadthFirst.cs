using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{
    class BreadthFirst
    {
        static bool done = false;
        public static node addNode(node mList)
        {

            node loopNode = new node(0, 0, 0, null);
            List<node> tList = new List<node>();
            foreach (node item in mList.nodelist)
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

                    tList.Add(new node(item.steps + 1, y, x, item));
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




            }
            loopNode.nodelist = tList;
            addNode(loopNode);

            return null;
        }
    }
}

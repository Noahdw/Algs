using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs
{
    class SpiralGen
    {
        public string[,] spiralLayout;


        private int rowsHalf;
        private int colsHalf;
        private  string wall = "1";
        private  string path = "0";
        private int state = 0;
        int xOffset = 0;
        int yOffset = 0;
        int quad = 0;
        private Random rand = new Random();
        public void CreateSpiral(int rows, int cols)
        {
            rowsHalf = rows/2;
            colsHalf = cols/2;

            spiralLayout = new string[rows, cols];
            //Creates board
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    spiralLayout[i, j] = wall;
                }

               
            }
            spiralLayout[rows / 2, cols/ 2] = path;
            int direction = 0;
           
            xOffset = 0;
            yOffset = 0;
            for (int j = 0; j < 500; j++)
            {
                quad = 2;

                for (int i = 1; i < rows/quad; i++)
            {
                //0 = left, 1 = same, 2 = right for top node

                int leave = rand.Next(0, 10);
                if (leave > 7)
                {
                    if (state == 0)
                    {
                        state = 2;
                    }

                    else if (state == 2)
                    {
                        state = 0;
                    }


                }
                if (leave > 4 && state == 1)
                {
                    state = direction;
                }
                if (state == 0)
                {
                    direction = 0;
                    xOffset++;
                    yOffset++;
                    if (leave < 4)
                    {
                        state = 1;
                    }

                }

                if (state == 2)
                {
                    direction = 2;
                    xOffset--;
                    yOffset--;
                    if (leave < 4)
                    {
                        state = 1;
                    }

                }
                spiralLayout[rows/ quad + i, cols/ quad - xOffset] = path; // top
                spiralLayout[rows / quad - i, cols / quad + xOffset] = path; // bottom
                spiralLayout[rows / quad - yOffset, cols / quad - i] = path; // left
                spiralLayout[rows / quad + yOffset, cols / quad + i] = path;
                }
                xOffset = 0;
                yOffset = 0;
            }
            ImageHelper image = new ImageHelper();
            image.CreateImage(spiralLayout, 1,"spiral");
        }

        
                
            
      
}
}

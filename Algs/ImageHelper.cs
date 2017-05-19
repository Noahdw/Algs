using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace Algs
{
    //This class is responsible for creating and saving an image of a completed maze
    class ImageHelper
    {
        Random rand = new Random();
        private int stride = 4;
        public void CreateImage(string[,] layout, int multiple,string id)
        {
            Bitmap bmp = new Bitmap(layout.GetLength(1) * multiple, layout.GetLength(0) * multiple, PixelFormat.Format32bppRgb);
            Rectangle grayRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(grayRect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;
            int numBytes = layout.GetLength(1) * layout.GetLength(0) * (multiple * multiple) * stride;
            //1.) convert to a 1d array with stride 4
            //Multiple makes it larger by a factor of the supplied value

            double[] result = new double[numBytes];
            int count = 0;
            for (int i = 0; i < layout.GetLength(0); i++)
            {
                for (int q = 0; q < multiple; q++)
                {
                    for (int j = 0; j < layout.GetLength(1); j++)
                    {
                        for (int l = 0; l < multiple; l++)
                        {

                            for (int k = 0; k < stride; k++)
                            {
                                if (layout[i, j] == MazeGen.wall)
                                {
                                    result[count] = 0;
                                    count++;
                                }
                                else if (layout[i, j] == MazeGen.path)
                                {
                                    result[count] = 255;
                                    count++;
                                }
                                else if (layout[i, j] == "2")
                                {
                                    result[count] = 127;
                                    count++;
                                }
                            }
                            result[count - 1] = 255; // Ensure the alpha value is off (on?)
                        }
                    }




                }
            }
            byte[] tempByteArray = result.Select(x => Convert.ToByte(x)).ToArray();
            Marshal.Copy(tempByteArray, 0, ptr, numBytes);
            bmp.UnlockBits(data);

            MemoryStream ms = new MemoryStream();
            bmp.Save(@"C:\Users\Puter\Pictures\maze\" + id + Program.runs +".jpg", ImageFormat.Png);
            ms.Position = 0;


            bmp.Dispose();
            SaveImage();
        }

        public void SaveImage()
        {

        }
    }
}

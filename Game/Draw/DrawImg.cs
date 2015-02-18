namespace Game.Draw
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;

    public class DrawImg
    {
        public static void Draw(string imagePath, string endString)
        {
            Image picture = Image.FromFile(imagePath);
            Console.SetBufferSize(picture.Width * 0x2, picture.Height * 0x2);
            FrameDimension dimension = new FrameDimension(picture.FrameDimensionsList[0x0]);
            int frameCount = picture.GetFrameCount(dimension);
            int left = Console.WindowLeft, top = Console.WindowTop;
            char[] chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            picture.SelectActiveFrame(dimension, 0x0);
            for (int i = 0x0; i < picture.Height; i++)
            {
                for (int x = 0x0; x < picture.Width; x++)
                {
                    Color color = ((Bitmap)picture).GetPixel(x, i);
                    int gray = (color.R + color.G + color.B) / 0x3;
                    int index = (gray * (chars.Length - 0x1)) / 0xFF;
                    Console.Write(chars[index]);
                }

                Thread.Sleep(70);
                Console.Write('\n');
            }

            Console.WriteLine(endString);
        }
    }
}
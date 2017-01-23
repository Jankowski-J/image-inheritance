using System;
using System.Drawing;
using System.IO;

namespace Inheritor
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = @"C:\dev\image-inheritance\testData";
            var firstImageName = "evil_face.jpg";
            var secondImageName = "evil_face_inv.jpg";

            var imageA = (Bitmap)Image.FromFile(Path.Combine(basePath, firstImageName));
            var imageB = (Bitmap)Image.FromFile(Path.Combine(basePath, secondImageName));

            var width = imageA.Width;
            var height = imageA.Height;
            var outputBitmap = new Bitmap(width, height);
            using (var graph = Graphics.FromImage(outputBitmap))
            {
                var imageSize = new Rectangle(0, 0, width, height);
                graph.FillRectangle(Brushes.White, imageSize);
            }

            var random = new Random();
            for (var wIndex = 0; wIndex < width; wIndex++)
            {
                for (var hIndex = 0; hIndex < height; hIndex++)
                {
                    var pixelA = imageA.GetPixel(wIndex, hIndex);
                    var pixelB = imageB.GetPixel(wIndex, hIndex);

                    //if (pixelA.ToArgb().Equals(Color.White.ToArgb()))
                    //{
                    //    outputBitmap.SetPixel(wIndex, hIndex, pixelB);
                    //    continue;
                    //}
                    //if (pixelB.ToArgb().Equals(Color.White.ToArgb()))
                    //{
                    //    outputBitmap.SetPixel(wIndex, hIndex, pixelA);
                    //    continue;
                    //}

                    var minRed = Math.Min(pixelA.R, pixelB.R);
                    var maxRed = Math.Max(pixelA.R, pixelB.R);
                    var redDiff = maxRed - minRed;

                    var minBlue = Math.Min(pixelA.B, pixelB.B);
                    var maxBlue = Math.Max(pixelA.B, pixelB.B);
                    var blueDiff = maxBlue - minBlue;

                    var minGreen = Math.Min(pixelA.G, pixelB.G);
                    var maxGreen = Math.Max(pixelA.G, pixelB.G);
                    var greenDiff = maxGreen - minGreen;

                    var percentageChange = random.Next(100);

                    var red = minRed + redDiff * percentageChange / 100;
                    var green = minGreen + greenDiff * percentageChange / 100;
                    var blue = minBlue + blueDiff * percentageChange / 100;

                    var color = Color.FromArgb(255, red, green, blue);
                    outputBitmap.SetPixel(wIndex, hIndex, color);
                }
            }

            var fileName = $"output_{DateTime.Now:HH-mm-ss}.png";
            outputBitmap.Save(fileName);
            imageA.Dispose();
            imageB.Dispose();
            outputBitmap.Dispose();
        }
    }
}

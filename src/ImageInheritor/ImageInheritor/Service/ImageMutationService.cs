using System;
using System.Drawing;
using Inheritor.Model;

namespace Inheritor.Service
{
    internal class ImageMutationService : IImageMutationService
    {
        public ImageMutationResult Mutate(IImage left, IImage right)
        {
            var width = left.Width;
            var height = right.Height;

            var random = new Random();

            var resultBitmap = BitmapImage.GetBlankBitmap(width, height);

            for (var wIndex = 0; wIndex < width; wIndex++)
            {
                for (var hIndex = 0; hIndex < height; hIndex++)
                {
                    var pixelA = left[wIndex, hIndex];
                    var pixelB = right[wIndex, hIndex];
                    var percentageChange = random.Next(100);

                    var red = GetChangedRed(pixelA, pixelB, percentageChange);
                    var green = GetChangedGreen(pixelA, pixelB, percentageChange);
                    var blue = GetChangedBlue(pixelA, pixelB, percentageChange);

                    var color = Color.FromArgb(255, red, green, blue);
                    resultBitmap[wIndex, hIndex] = color;
                }
            }

            return ImageMutationResult.Succeed(resultBitmap);
        }

        private static int GetChangedGreen(Color pixelA, Color pixelB, int percentageChange)
        {
            var minGreen = Math.Min(pixelA.G, pixelB.G);
            var maxGreen = Math.Max(pixelA.G, pixelB.G);
            var greenDiff = maxGreen - minGreen;
            var green = minGreen + greenDiff * percentageChange / 100;
            return green;
        }

        private static int GetChangedBlue(Color pixelA, Color pixelB, int percentageChange)
        {
            var minBlue = Math.Min(pixelA.B, pixelB.B);
            var maxBlue = Math.Max(pixelA.B, pixelB.B);
            var blueDiff = maxBlue - minBlue;
            var blue = minBlue + blueDiff * percentageChange / 100;
            return blue;
        }

        private static int GetChangedRed(Color pixelA, Color pixelB, int percentageChange)
        {
            var minRed = Math.Min(pixelA.R, pixelB.R);
            var maxRed = Math.Max(pixelA.R, pixelB.R);
            var redDiff = maxRed - minRed;
            var red = minRed + redDiff * percentageChange / 100;
            return red;
        }
    }
}

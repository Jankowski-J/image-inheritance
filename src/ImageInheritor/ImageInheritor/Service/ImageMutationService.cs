using System;
using System.Drawing;
using Inheritor.Model;

namespace Inheritor.Service
{
    internal class ImageMutationService : IImageMutationService
    {
        private Random _randomGenerator = new Random();

        public ImageMutationResult Mutate(IImage left, IImage right)
        {
            var width = left.Width;
            var height = right.Height;

            var resultBitmap = BitmapImage.GetBlankBitmap(width, height);

            for (var wIndex = 0; wIndex < width; wIndex++)
            {
                for (var hIndex = 0; hIndex < height; hIndex++)
                {
                    var pixelA = left[wIndex, hIndex];
                    var pixelB = right[wIndex, hIndex];
                    var percentageChange = _randomGenerator.Next(100);
                    var shouldMutate = ShouldMutate(pixelA, pixelB);

                    var red = GetChangedRed(pixelA, pixelB, percentageChange, shouldMutate);
                    var green = GetChangedGreen(pixelA, pixelB, percentageChange, shouldMutate);
                    var blue = GetChangedBlue(pixelA, pixelB, percentageChange, shouldMutate);

                    var color = Color.FromArgb(255, red, green, blue);
                    resultBitmap[wIndex, hIndex] = color;
                }
            }

            return ImageMutationResult.Succeed(resultBitmap);
        }

        private bool ShouldMutate(Color left, Color right)
        {
            if (left.ToArgb() == Color.White.ToArgb() || right.ToArgb() == Color.White.ToArgb())
            {
                var rand = _randomGenerator.NextDouble();

                return rand >= 0.8;
            }

            return true;
        }

        private static int GetChangedGreen(Color pixelA, Color pixelB, int percentageChange, bool shouldMutate)
        {
            if (!shouldMutate)
            {
                return 255;
            }
            var minGreen = Math.Min(pixelA.G, pixelB.G);
            var maxGreen = Math.Max(pixelA.G, pixelB.G);
            var greenDiff = maxGreen - minGreen;
            var green = minGreen + greenDiff * percentageChange / 100;
            return green;
        }

        private static int GetChangedBlue(Color pixelA, Color pixelB, int percentageChange, bool shouldMutate)
        {
            if (!shouldMutate)
            {
                return 255;
            }
            var minBlue = Math.Min(pixelA.B, pixelB.B);
            var maxBlue = Math.Max(pixelA.B, pixelB.B);
            var blueDiff = maxBlue - minBlue;
            var blue = minBlue + blueDiff * percentageChange / 100;
            return blue;
        }

        private static int GetChangedRed(Color pixelA, Color pixelB, int percentageChange, bool shouldMutate)
        {
            if (!shouldMutate)
            {
                return 255;
            }
            var minRed = Math.Min(pixelA.R, pixelB.R);
            var maxRed = Math.Max(pixelA.R, pixelB.R);
            var redDiff = maxRed - minRed;
            var red = minRed + redDiff * percentageChange / 100;
            return red;
        }
    }
}

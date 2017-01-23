using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Inheritor.Model;
using NUnit.Framework;

namespace Inheritor.Tests
{
    public static class ImageAssertionHelper
    {
        public static void AreAllPixelsSameColor(IImage image, Color targetColor)
        {
            var width = image.Width;
            var height = image.Height;

            var areAllSame = true;
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var color = image[x, y].ToArgb();
                    var areTheSame = targetColor.ToArgb() == color;
                    areAllSame = areTheSame && areAllSame;
                }
            }
            Assert.IsTrue(areAllSame);
        }

        public static void HasAtLeastOnePixelWithColorDifferentThan(IImage image, Color targetColor)
        {
            var width = image.Width;
            var height = image.Height;
            ((BitmapImage)image).ToFile();
            var colorToCompare = targetColor.ToArgb();
            var atLeastOneDifferent = true;
            for (var x = 0; x < width; x++)
            {
                var areTheSame = true;
                for (var y = 0; y < height; y++)
                {
                    var color = image[x, y].ToArgb();
                    areTheSame = colorToCompare == color;
                    atLeastOneDifferent = areTheSame;
                    if (!areTheSame)
                    {
                        break;
                    }
                }
                if (!areTheSame)
                {
                    break;
                }
            }

            Assert.False(atLeastOneDifferent);
        }
    }
}

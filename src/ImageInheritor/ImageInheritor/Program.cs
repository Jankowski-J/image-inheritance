using System;
using System.Drawing;
using System.IO;
using Inheritor.Model;
using Inheritor.Service;

namespace Inheritor
{
    class Program
    {
        static void Main(string[] args)
        {
            const string basePath = @"C:\dev\image-inheritance\testData";
            const string firstImageName = "evil_face.jpg";
            const string secondImageName = "evil_face_inv.jpg";

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

            var service = new ImageMutationService();
            var left = new BitmapImage(imageA);
            var right = new BitmapImage(imageB);

            var result = service.Mutate(left, right);

            var fileName = $"output_{DateTime.Now:HH-mm-ss}.png";
            result.Image.ToFile(fileName);
            outputBitmap.Save(fileName);
            imageA.Dispose();
            imageB.Dispose();
            outputBitmap.Dispose();
        }
    }
}

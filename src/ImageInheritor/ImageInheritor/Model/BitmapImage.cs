﻿using System;
using System.Drawing;

namespace Inheritor.Model
{
    public class BitmapImage : IImage
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private readonly Bitmap _baseImage;

        public Color this[int x, int y]
        {
            get { return _baseImage.GetPixel(x, y); }
            set { _baseImage.SetPixel(x, y, value); }
        }

        public BitmapImage(Bitmap bitmap)
        {
            _baseImage = bitmap;
            Width = _baseImage.Width;
            Height = _baseImage.Height;
        }

        public static BitmapImage GetBlankBitmap(int width, int height, Color blankColor)
        {
            ValidateSize(width, height);

            var outputBitmap = new Bitmap(width, height);
            using (var graph = Graphics.FromImage(outputBitmap))
            using (var brush = new SolidBrush(blankColor))
            {
                var imageSize = new Rectangle(0, 0, width, height);
                graph.FillRectangle(brush, imageSize);
            }
            return new BitmapImage(outputBitmap);
        }

        private static void ValidateSize(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
        }

        public static BitmapImage GetBlankBitmap(int width, int height)
        {
            return GetBlankBitmap(width, height, Color.White);
        }
    }
}
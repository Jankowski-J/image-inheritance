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
    }
}
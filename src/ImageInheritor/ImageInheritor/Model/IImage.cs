using System.Drawing;

namespace Inheritor.Model
{
    public interface IImage
    {
        int Width { get; }
        int Height { get; }

        Color this[int i, int y] { get; set; }
    }
}
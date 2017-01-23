using System;
using Inheritor.Model;

namespace Inheritor.Service
{
    public class InheritanceService : IInheritanceService
    {
        public IImage Inherit(IImage left, IImage right)
        {
            var width = left.Width;
            var height = right.Height;

            return new BitmapImage(null);
        }
    }
}

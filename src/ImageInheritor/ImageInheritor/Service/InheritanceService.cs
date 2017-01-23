using Inheritor.Model;

namespace Inheritor.Service
{
    internal class InheritanceService : IInheritanceService
    {
        public ImageInheritanceResult Inherit(IImage left, IImage right)
        {
            var width = left.Width;
            var height = right.Height;

            return ImageInheritanceResult.Fail("placeholder message");
        }
    }
}

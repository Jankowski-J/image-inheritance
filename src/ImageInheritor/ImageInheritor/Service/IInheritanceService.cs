using Inheritor.Model;

namespace Inheritor.Service
{
    public interface IInheritanceService
    {
        ImageInheritanceResult Inherit(IImage left, IImage right);
    }
}

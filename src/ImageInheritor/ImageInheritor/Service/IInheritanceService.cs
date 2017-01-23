using Inheritor.Model;

namespace Inheritor.Service
{
    public interface IInheritanceService
    {
        IImage Inherit(IImage left, IImage right);
    }
}

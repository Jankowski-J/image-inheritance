using Inheritor.Model;

namespace Inheritor.Service
{
    public interface IImageMutationService
    {
        ImageMutationResult Mutate(IImage left, IImage right);
    }
}

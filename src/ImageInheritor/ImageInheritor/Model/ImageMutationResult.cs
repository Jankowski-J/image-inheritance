namespace Inheritor.Model
{
    public class ImageMutationResult
    {
        public bool IsSuccess { get; private set; }
        public IImage Image { get; private set; }
        public string ErrorMessage { get; private set; }

        protected ImageMutationResult(IImage image)
        {
            Image = image;
            ErrorMessage = string.Empty;
        }

        public static ImageMutationResult Succeed(IImage image)
        {
            return new ImageMutationResult(image)
            {
                IsSuccess = true
            };
        }

        public static ImageMutationResult Fail(string message, IImage image = null)
        {
            return new ImageMutationResult(image)
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }
    }
}

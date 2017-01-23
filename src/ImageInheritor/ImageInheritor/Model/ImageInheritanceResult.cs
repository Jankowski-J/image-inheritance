namespace Inheritor.Model
{
    public class ImageInheritanceResult
    {
        public bool IsSuccess { get; private set; }
        public IImage Image { get; private set; }
        public string ErrorMessage { get; private set; }

        protected ImageInheritanceResult(IImage image)
        {
            Image = image;
            ErrorMessage = string.Empty;
        }

        public static ImageInheritanceResult Succeed(IImage image)
        {
            return new ImageInheritanceResult(image)
            {
                IsSuccess = true
            };
        }

        public static ImageInheritanceResult Fail(string message, IImage image = null)
        {
            return new ImageInheritanceResult(image)
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }
    }
}

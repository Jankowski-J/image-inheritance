using System.Drawing;
using Inheritor.Model;
using Inheritor.Service;
using NUnit.Framework;

namespace Inheritor.Tests.Service
{
    [TestFixture]
    public class ImageMutationServiceTests
    {
        private ImageMutationService _target;

        [SetUp]
        public void Initialize()
        {
            _target = new ImageMutationService();
        }

        [Test]
        public void Mutate_TwoBlankImages_ShouldSuceed()
        {
            // Arrange 
            var imageA = BitmapImage.GetBlankBitmap(20, 20);
            var imageB = BitmapImage.GetBlankBitmap(20, 20);

            // Act
            var result = _target.Mutate(imageA, imageB);

            // Assert
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Mutate_TwoBlankImages_ShouldReturnABlankImage()
        {
            // Arrange 
            var imageA = BitmapImage.GetBlankBitmap(20, 20);
            var imageB = BitmapImage.GetBlankBitmap(20, 20);

            // Act
            var result = _target.Mutate(imageA, imageB);

            // Assert
            Assert.IsNotNull(result.Image);
            ImageAssertionHelper.AreAllPixelsSameColor(imageA, Color.White);
        }

        [Test]
        public void Mutate_OneWhiteOneBlackImage_ShouldSucceed()
        {
            // Arrange 
            var imageA = BitmapImage.GetBlankBitmap(20, 20);
            var imageB = BitmapImage.GetBlankBitmap(20, 20, Color.Black);

            // Act
            var result = _target.Mutate(imageA, imageB);

            // Assert
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Mutate_OneWhiteOneBlackImage_ShouldCreateModifiedImage()
        {
            // Arrange 
            var imageA = BitmapImage.GetBlankBitmap(20, 20);
            var imageB = BitmapImage.GetBlankBitmap(20, 20, Color.Black);

            // Act
            var result = _target.Mutate(imageA, imageB);

            // Assert
            Assert.IsNotNull(result.Image);
            ImageAssertionHelper.HasAtLeastOnePixelWithColorDifferentThan(result.Image, Color.White);
            ImageAssertionHelper.HasAtLeastOnePixelWithColorDifferentThan(result.Image, Color.Black);
        }
    }
}

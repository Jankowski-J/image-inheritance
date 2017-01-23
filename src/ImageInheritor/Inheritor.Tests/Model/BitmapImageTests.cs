using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Inheritor.Model;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Inheritor.Tests.Model
{
    [TestFixture]
    public class BitmapImageTests
    {
        private BitmapImage _target;

        [SetUp]
        public void Initialize()
        {
            var bitmap = (Bitmap)Image.FromFile(Path.Combine(AssemblyDirectory, "testPic_1.png"));
            _target = new BitmapImage(bitmap);
        }

        [Test]
        public void Indexer_PixelInTopLeftCorner_ShouldContainCorrectColor()
        {
            // Arrange
            var expected = Color.White.ToArgb();

            // Act
            var color = _target[0, 0].ToArgb();
           
            // Assert
            Assert.AreEqual(expected, color);
        }

        [Test]
        public void Indexer_PixelInBottomRightCorner_ShouldContainCorrectColor()
        {
            // Arrange
            var expected = Color.Black.ToArgb();

            // Act
            var color = _target[_target.Width - 1, _target.Height - 1].ToArgb();
            
            // Assert
            Assert.AreEqual(expected, color);
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        [Test]
        public void GetBlankImage_ForValidDimensions_ReturnsValidImage()
        {
            // Arrange
            const int width = 20;
            const int height = 20;
            var expectedColor = Color.White.ToArgb();

            // Act
            var result = BitmapImage.GetBlankBitmap(width, height);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedColor, result[0, 0].ToArgb());
        }

        [Test]
        public void GetBlankImage_ForValidDimensions_ReturnsImageWithCorrectDimensions()
        {
            // Arrange
            const int width = 20;
            const int height = 50;

            // Act
            var result = BitmapImage.GetBlankBitmap(width, height);

            // Assert
            Assert.AreEqual(width, result.Width);
            Assert.AreEqual(height, result.Height);
        }

        [Test]
        public void GetBlankImage_ForInvalidDimensions_ReturnsShouldThrowException()
        {
            // Arrange
            const int width = -1;
            const int height = 0;

            // Act
            Action action = () => BitmapImage.GetBlankBitmap(width, height);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => action());
        }
    }
}

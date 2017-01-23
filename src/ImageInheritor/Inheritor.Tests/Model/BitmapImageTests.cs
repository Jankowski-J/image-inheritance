using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Inheritor.Model;
using NUnit.Framework;

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
            var color = _target[0, 0].ToArgb();
            var expected = Color.White.ToArgb();

            Assert.AreEqual(expected, color);
        }

        [Test]
        public void Indexer_PixelInBottomRightCorner_ShouldContainCorrectColor()
        {
            var color = _target[_target.Width - 1, _target.Height - 1].ToArgb();
            var expected = Color.Black.ToArgb();

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
    }
}

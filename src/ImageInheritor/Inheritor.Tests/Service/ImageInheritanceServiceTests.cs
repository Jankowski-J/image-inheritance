using Inheritor.Service;
using NUnit.Framework;

namespace Inheritor.Tests.Service
{
    [TestFixture]
    public class ImageInheritanceServiceTests
    {
        private InheritanceService _target;

        [SetUp]
        public void Initialize()
        {
            _target = new InheritanceService();
        }
    }
}

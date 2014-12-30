using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySerializer.Test.Misc
{
    [TestClass]
    public class NullTrailingMemberTests : TestBase
    {
        [TestMethod]
        public void NullTrailingMemberTest()
        {
            var container = new NullTrailingMemberClassContainer();

            Roundtrip(container, 8);

            container.Inner.OptionalParameter = 5;

            Roundtrip(container, 9);
        }
    }
}
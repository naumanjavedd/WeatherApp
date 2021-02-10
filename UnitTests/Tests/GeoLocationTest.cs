using BLL.GeoCoding;
using Moq;
using NUnit.Framework;
using Services.GeoCoding;

namespace UnitTests.Tests
{
    [TestFixture]

    class GeoLocationTest
    {
        private IGeoCodingBLL GeoCodingBLL= null;
        private Mock<GeoCodingService> MockGeoCodingService = null;
        string CorrectAddress = "777 Brockton Avenue, Abington MA 2351";
        string InCorrectAddress = "jsfkjfhzs";
        [SetUp]
        public void SetUp()
        {
            MockGeoCodingService = new Mock<GeoCodingService>() { CallBase = true };
            GeoCodingBLL = new GeoCodingBLL(MockGeoCodingService.Object);
        }

        [Test]
        public void Check_If_Valid_Address_Works()
        {
            var rs = GeoCodingBLL.GetCoordinates(CorrectAddress);
            Assert.IsTrue(rs != null && rs.x!=0 && rs.y!=0);
        }

        [Test]
        public void Check_If_InValid_Address_Does_Not_Works()
        {
            var rs = GeoCodingBLL.GetCoordinates(InCorrectAddress);
            Assert.IsTrue(rs == null || (rs.x==0 && rs.y==0));
        }

    }

}

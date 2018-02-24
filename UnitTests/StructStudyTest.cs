using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructStudy;

namespace UnitTests
{
    [TestClass]
    public class StructStudyTest
    {

        [TestMethod]
        public void StructValueType()
        {
            var latLongStructType = new LatLongStruct()
            {
                Latitude = 1,
                Longitude = 1
            };

            var latLongStructTypeModed = StructStudyHelpers.ModStruct(latLongStructType);

            Assert.AreNotEqual(latLongStructType, latLongStructTypeModed);
        }

        [TestMethod]
        public void StructRefType()
        {
            var latLongClass = new LatLongClass()
            {
                Latitude = 1,
                Longitude = 1
            };

            var latLongClassModed = StructStudyHelpers.ModClass(latLongClass);

            Assert.AreSame(latLongClass, latLongClassModed);
        }

    }
}

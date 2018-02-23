using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeStudy;


namespace UnitTests
{
    [TestClass]
    public class TypeStudyTests
    {
        readonly Address testAddress1 = new Address()
        {
            Country = "Canada",
            Region = "Ontario",
            StreetName = "Yonge St.",
            StreetNumber = 123,
            UnitNumber = 123
        };

        readonly Address testAddressUnit0 = new Address()
        {
            Country = "Canada",
            Region = "Ontario",
            StreetName = "Yonge St.",
            StreetNumber = 123,
            UnitNumber = 0 
        };

        // Note: This test needs to be run first because it tests static fields, which are affected by later instances of the the objects
        [TestMethod]
        public void StaticFieldTesting()
        {
            Apartment firstApartment = new Apartment()
            {
                Address = testAddress1
            };

            Assert.AreEqual(Apartment.TotalApts, Residence.TotalResidence);

            House firstHouse = new House()
            {
                Address = testAddressUnit0
            };

            // Show that the Residence class static field applies acrosss all classes that derive from it. 
            Assert.AreNotEqual(House.TotalHomes, House.TotalResidence);
            Assert.AreNotEqual(Apartment.TotalApts, Residence.TotalResidence);


        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException),
        "The House object should throw an exception")]
        public void TestingHouseAddressWithUnitNumber()
        {
            House firstHouse = new House()
            {
                Address = testAddress1
            };

            Assert.AreNotEqual(testAddress1.UnitNumber, firstHouse.Address.UnitNumber);
        }

        [TestMethod]
        public void InstanceConstructorTesting()
        {
            House houseOne = new House(testAddressUnit0);
            Assert.AreSame(houseOne.Address, testAddressUnit0);
        }

        [TestMethod]
        public void AddingOccupantToHouse()
        {
            House firstHouse = new House()
            {
                Address = testAddressUnit0
            };

            firstHouse.AddOccupant("John", "Smith");
            Assert.AreEqual(firstHouse.Occupants.Count, 1); 
        }

        [TestMethod]
        public void UpcastingDowncastingTest()
        {
            HistoricalHome secondHouseHistorical = new HistoricalHome()
            {
                Address = new Address
                {
                    Country = "USA",
                    Region = "California",
                    City = "San Diego"
                },
                YearBuilt = 1931
            };

            House secondHouseUpcasted = secondHouseHistorical;
            
            // The upcasting doesn't effect equivalancy
            Assert.AreEqual(secondHouseHistorical, secondHouseUpcasted);

            //In Fact, the upcasted variable is just a reference to the original, but with limited scope. 
            Assert.AreSame(secondHouseUpcasted, secondHouseHistorical);
        }

        [TestMethod]
        public void TestingInitializers()
        {
            Person person = new Person("John", "Doe")
            {
                Address = testAddress1
            };

            Person personTwo = new Person("John", "Doe", testAddress1);

            Assert.AreEqual(person.FullName(), "John Doe");
            Assert.AreEqual(person.FullNameProperty, "John Doe");
            Assert.AreEqual(person.FullName(), personTwo.FullName());
            Assert.AreEqual(person.Address, personTwo.Address);

            //Testing the Indexer
            Assert.AreEqual(person[0], "John");

            //Doesn't work:
            //PrivatePerson privatePerson = new PrivatePerson("John", "Doe");
            //PrivatePerson privatePerson = new PrivatePerson("John", "Doe", testAddress1);
            // Testing a static method call instance creation
            PrivatePerson privatePerson = PrivatePerson.CreatePrivatePerson("John", "Doe", testAddress1);

            Assert.AreEqual(privatePerson.FullName(), "John Doe");
        }
    }
}

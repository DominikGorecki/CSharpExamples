using System;
using System.Collections.Generic;
using System.Text;

namespace TypeStudy 
{
    /// <summary>
    /// Interface used for objects that have a physical location with an address--items that can be put on a map
    /// </summary>
    public interface ILocation
    {
        Address Address { get; set; }
    }

    public class Address
    {
        public int StreetNumber { get; set; }
        public int UnitNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

    public class Person : ILocation
    {
        string[] names;

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
            names = FullNameProperty.Split();
        }

        // Indexer for Person object 
        public string this [int i]
        {
            get { return names[i];  }
        }

        // Overloading constructor
        public Person(string first, string last, Address address) : this(first, last)
        {
            Address = address; 
        }

        // Expression-bodied methods
        public string FullName() => FirstName + " " + LastName;

        // Expression-bodied properties
        public string FullNameProperty => FirstName + " " + LastName;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    public class PrivatePerson: Person
    {
        // Make constructor private to force construction through static method "Create"
        PrivatePerson(string first, string last): base(first, last) { }
        //PrivatePerson(string first, string last, Address address) : base(first, last, address) { }
        private static int weirdPeople = 0;

        public static PrivatePerson CreatePrivatePerson(string first, string last, Address address)
        {
            weirdPeople++;
            return new PrivatePerson(first, last) { Address = address };
        }
    }

    public abstract class Residence : ILocation
    {
        private HashSet<Person> occupants = new HashSet<Person>();
        private static int totalResidences = 0;

        public Residence()
        {
            Address = new Address();
            ResidenceInit();
        }

        public Residence(Address address)
        {
            this.Address = address; // Using the keyword "this" to clearly specify that it's a property and not an Object class name because of naming choice ambiguity. 
            ResidenceInit();
        }

        // We'll put statements in here that are common to all the instance constructors.
        private void ResidenceInit()
        {
            totalResidences++;
        }

        public HashSet<Person> Occupants { get { return occupants; } }
        public virtual Address Address { get; set; }

        public void AddOccupant(string first, string last) {
            occupants.Add(new Person(first, last));
        }

        public static int TotalResidence { get { return totalResidences;  } }
    }

    public class House : Residence
    {
        private static int totalHomes = 0;
        private Address address;

        public House() : base()
        {
            totalHomes++;
        }

        public House(Address address) : base(address) { }

        public override Address Address
        {
            get { return address; }
            set
            {
                if(value.UnitNumber != 0) throw new ArgumentOutOfRangeException("There should be no unit number on houses"); 
                address = value;
            }
        }

        public static int TotalHomes { get { return totalHomes;  } }
    }

    public class Apartment : Residence
    {
        private static int totalApts = 0;
        public override Address Address { get; set; }

        public Apartment() : base()
        {
            totalApts++;
        }

        public static int TotalApts { get { return totalApts; }  }
    }

    public class HistoricalHome : House
    {
        public int YearBuilt { get; set; }
        public string HistoricalSignificance { get; set; }
    }
}

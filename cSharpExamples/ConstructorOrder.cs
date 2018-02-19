using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorOrder 
{
    public static class OrderTracker
    {
        public static List<string> StringTracker = new List<string>();
        public static string TrackString(string trackThisString)
        {
            StringTracker.Add(trackThisString);
            return trackThisString;
        }

        public static void DisplayTrackStringAndClear()
        {
            Console.WriteLine("The order of the execution is from top to bottom.");
            Console.WriteLine("-------------------------------------------------");
            foreach(string s in OrderTracker.StringTracker)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("The order string tracker will now be cleared");
            OrderTracker.StringTracker = new List<string>();
        }
    }

    public class InitOrderBase
    {
        string baseField = OrderTracker.TrackString("BASE CLASS: Init of instance field");

        public InitOrderBase(string baseParm)
        {
            OrderTracker.TrackString("BASE CLASS: Execution of constructor");
        }
    }

    public class InitOrderDerived : InitOrderBase
    {
        string derivedField = OrderTracker.TrackString("DERIVED CLASS: \t Init of instance field");

        public InitOrderDerived(string passedInPar) 
            : base(OrderTracker.TrackString("DERIVED CLASS: \t Execution of call to base in parameter"))
        {
            OrderTracker.TrackString("DERIVED CLASS: \t Execution constructor");
        }
    }
}

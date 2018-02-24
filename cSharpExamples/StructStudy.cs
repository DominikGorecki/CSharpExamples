namespace StructStudy 
{
    public static class StructStudyHelpers
    {
        public static LatLongStruct ModStruct(LatLongStruct llStruct)
        {
            llStruct.Latitude *= (decimal)1.1;
            llStruct.Longitude *= (decimal)1.1;
            return llStruct;
        }

        public static LatLongClass ModClass(LatLongClass llClass)
        {
            llClass.Longitude *= (decimal)1.1;
            llClass.Latitude *= (decimal)1.1;
            return llClass;
        }

    }

    public struct LatLongStruct
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class LatLongClass
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}

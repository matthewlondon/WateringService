using CsvHelper.Configuration;

namespace WateringService.Models
{
    public class Tree
    {
        public Guid? TreeId { get; set; }
        public string Name { get; set; }
        public int Gallons { get; set; }
        public Guid ParkId { get; set; }
        public Park Park { get; set; }


    }
    //public sealed class TreeMap : ClassMap<Tree>
    //{
    //    public TreeMap()
    //    {
    //        Map(m => m.Park).Name("Park");
    //        Map(m => m.Name).Name("Name");
    //        Map(m => m.Gallons).Name("Gallons");
    //        Map(m => m.TreeId).Ignore();
    //    }
    //}
}

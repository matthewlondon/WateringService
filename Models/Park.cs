namespace WateringService.Models
{
    public class Park
    {
        public Guid ParkId { get; set; }
        public string Name { get; set; }
        public ICollection<RainGauge> RainGauges { get; set;}
        public ICollection<Tree> Trees { get; set;}

    }
}

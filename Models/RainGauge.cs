using System.ComponentModel.DataAnnotations;

namespace WateringService.Models
{
    public class RainGauge
    {
        [Key]
        public Guid GaugeId { get; set; }
        public string GaugeName { get; set; }
        public double Rainfall { get; set; }
        public Guid ParkId { get; set; }
        public Park Park { get; set; }



    }
}

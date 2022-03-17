using System.ComponentModel;

namespace GoodForMooTurf.Models
{
    public class ReportData
    {
        public string Description { get; set; }
        [DisplayName("Result")]
        public string Value { get; set; }
    }
}

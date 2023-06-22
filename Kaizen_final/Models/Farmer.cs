using System.Collections.Generic;

namespace Kaizen_final.Models
{
    public class Farmer
    {
        public int farmerId { get; set; }
        public string farmerName { get; set; }
        public string farmerEmail { get; set; }
        public string farmerPhoneNumber { get; set; }

        public List<Tea> Teas { get; set; }

    }
}

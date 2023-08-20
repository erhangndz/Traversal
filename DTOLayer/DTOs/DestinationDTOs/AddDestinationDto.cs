using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.DestinationDTOs
{
    public class AddDestinationDto
    {
        public string City { get; set; }
        public string StayDuration { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
    }
}

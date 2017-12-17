using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Domain.Entities
{
    public class Flight : Journey
    {
        [Required]
        public string FlightNumber { get; set; }
    }
}

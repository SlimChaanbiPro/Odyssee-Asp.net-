using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Domain.Entities
{
    public class RiverCruise : Journey
    {
        [Required]
        public string NameOfTheBoat { get; set; }
        public string PortOfRegistration { get; set; }
    }
}

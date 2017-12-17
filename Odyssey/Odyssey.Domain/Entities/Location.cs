using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Domain.Entities
{
    public class Location
    {
        [Key]
        public string LocationCode { get; set; }
        public string LocationName { get; set; }


        [Required]
        public LocationType LocationType { get; set; }

        public ICollection<Journey> Departures { get; set; }
        public ICollection<Journey> Arrives { get; set; }
    }
}

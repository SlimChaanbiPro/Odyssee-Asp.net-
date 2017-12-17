using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Domain.Entities
{
    public class OperatingCompany
    {
        public int OperatingCompanyId { get; set; }
        public string OperatingCompanyName { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string OperatingCompanyDetails { get; set; }

        public virtual ICollection<Journey> Journeys { get; set; }
    }
}

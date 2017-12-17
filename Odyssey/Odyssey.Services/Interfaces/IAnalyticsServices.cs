using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public interface IAnalyticsServices : IDisposable
    {
        ICollection<Location> GetBestDestinations(int number);
    }
}

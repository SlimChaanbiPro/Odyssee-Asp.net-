using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data.Interfaces
{
    public interface IDatabaseFactory : IDisposable 
    {
        OdysseyContext DataContext { get; } 
    }
}

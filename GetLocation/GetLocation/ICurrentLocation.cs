using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLocation
{
    public interface ICurrentLocation
    {
        Task<GPSCoordinates> GetCurrentCoordinates();
    }
}

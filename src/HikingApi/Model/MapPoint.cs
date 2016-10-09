using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public class MapPoint
    {
        public string MapPointId { get; set; }
        public string TrailId { get; set; }
        public double Order { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public class Trail
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public decimal Length { get; set; }
        public decimal Difficulty { get; set; }
        public List<MapPoint> MapPoints { get; set; }
}
}

using HikingApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public class TrailRepository : ITrailRepository
    {
        public bool Add(Trail trail)
        {
            trail.Key = Guid.NewGuid().ToString();
            return true;
        }

        public Trail Find(string key)
        {
            if (key == null)
            {
                return null;
            }
            return new Trail() { Key = key };
        }

        public IEnumerable<Trail> GetAll()
        {
            return new List<Trail>()
            {
                Find("123"),
                Find("234"),
                Find("345")
            };
        }

        public IEnumerable<Trail> GetNear(Trail trail)
        {
            return GetAll();
        }

        public IEnumerable<Trail> GetNear(MapPoint mapPoint)
        {
            return GetAll();
        }

        public IEnumerable<Trail> GetNear(double latitude, double longitude)
        {
            return GetAll();
        }

        public Trail Remove(Trail trail)
        {
            return new Trail() { Key = trail.Key };
        }

        public Trail Remove(string key)
        {
            return new Trail() { Key = key };
        }

        public bool Update(Trail trail)
        {
            return true;
        }
    }
}

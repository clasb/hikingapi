using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model.Interfaces
{
    public interface ITrailRepository
    {
        bool Add(Trail trail);
        bool Update(Trail trail);
        IEnumerable<Trail> GetAll();
        IEnumerable<Trail> GetNear(double latitude, double longitude);
        IEnumerable<Trail> GetNear(MapPoint mapPoint);
        IEnumerable<Trail> GetNear(Trail trail);
        Trail Find(string key);
        Trail Remove(string key);
        Trail Remove(Trail trail);
    }
}

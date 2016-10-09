using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model.Interfaces
{
    public interface ITrailRepository
    {
        Task<bool> Add(Trail trail);
        Task<bool> Update(Trail trail);
        Task<IEnumerable<Trail>> GetAll();
        Task<IEnumerable<Trail>> GetNear(double latitude, double longitude);
        Task<IEnumerable<Trail>> GetNear(MapPoint mapPoint);
        Task<IEnumerable<Trail>> GetNear(Trail trail);
        Task<Trail> Find(string key);
        Task<Trail> Remove(string key);
        Task<Trail> Remove(Trail trail);
    }
}

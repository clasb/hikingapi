using HikingApi.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public class TrailRepository : ITrailRepository
    {
        private HikingContext _context;

        public TrailRepository(HikingContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Trail trail)
        {
            trail.TrailId = IdHelper.GetId();
            foreach (var point in trail.MapPoints)
            {
                point.TrailId = trail.TrailId;
                point.MapPointId = IdHelper.GetId();
            }
            _context.Trails.Add(trail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Trail> Find(string id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Trails.Include(t => t.MapPoints).FirstAsync(t => t.TrailId == id);
        }

        public async Task<IEnumerable<Trail>> GetAll()
        {
            return await _context.Trails.ToListAsync();
        }

        public async Task<IEnumerable<Trail>> GetNear(Trail trail)
        {
            return await GetAll();
        }

        public async Task<IEnumerable<Trail>> GetNear(MapPoint mapPoint)
        {
            return await GetAll();
        }

        public async Task<IEnumerable<Trail>> GetNear(double latitude, double longitude)
        {
            return await GetAll();
        }

        public async Task<Trail> Remove(Trail trail)
        {
            return new Trail() { TrailId = trail.TrailId };
        }

        public async Task<Trail> Remove(string key)
        {
            return new Trail() { TrailId = key };
        }

        public async Task<bool> Update(Trail trail)
        {
            return true;
        }
    }
}

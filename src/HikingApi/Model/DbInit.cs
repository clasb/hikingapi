using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HikingApi.Model
{
    public static class DbInit
    {
        public static void Init(HikingContext context)
        {
            if (!context.Trails.Any())
            {
                var trails = new List<Trail>()
                {
                    new Trail()
                    {
                        TrailId = IdHelper.GetId(),
                        Name = "First trail",
                        Description = "First trail description some text and some more text and again some text to fill up some space bla bla bla...",
                        Difficulty = 9.4M,
                        Rating = 4.5M,
                        Length = 10.4M
                    },
                    new Trail()
                    {
                        TrailId = IdHelper.GetId(),
                        Name = "Second trail",
                        Description = "Second trail description some text and some more text and again some text to fill up some space bla bla bla...",
                        Difficulty = 7.4M,
                        Rating = 2.2M,
                        Length = 1.2M
                    },
                    new Trail()
                    {
                        TrailId = IdHelper.GetId(),
                        Name = "Third trail",
                        Description = "Third trail description some text and some more text and again some text to fill up some space bla bla bla...",
                        Difficulty = 9.4M,
                        Rating = 4.5M,
                        Length = 10.4M
                    },
                    new Trail()
                    {
                        TrailId = IdHelper.GetId(),
                        Name = "Fourth trail",
                        Description = "Fourth trail description some text and some more text and again some text to fill up some space bla bla bla...",
                        Difficulty = 5.4M,
                        Rating = 2.5M,
                        Length = 40.4M
                    },
                };

                foreach (var trail in trails)
                {
                    context.Trails.Add(trail);
                }

                context.SaveChanges();
            }


            if (!context.MapPoints.Any())
            {
                var trails = context.Trails.ToList();
                foreach (var trail in trails)
                {
                    var points = new List<MapPoint>()
                    {
                        new MapPoint()
                        {
                            MapPointId = IdHelper.GetId(),
                            TrailId = trail.TrailId,
                            Elevation = 240.5,
                            Latitude = 63.106300,
                            Longitude = 13.798203,
                            Order = 1
                        },
                        new MapPoint()
                        {
                            MapPointId = IdHelper.GetId(),
                            TrailId = trail.TrailId,
                            Elevation = 240.5,
                            Latitude = 63.106489,
                            Longitude = 13.798460,
                            Order = 2 
                        },
                        new MapPoint()
                        {
                            MapPointId = IdHelper.GetId(),
                            TrailId = trail.TrailId,
                            Elevation = 240.5,
                            Latitude = 63.106887,
                            Longitude = 13.799039,
                            Order = 3
                        },
                        new MapPoint()
                        {
                            MapPointId = IdHelper.GetId(),
                            TrailId = trail.TrailId,
                            Elevation = 240.5,
                            Latitude = 63.107329,
                            Longitude = 13.799726,
                            Order = 4
                        }
                    };

                    foreach (var point in points)
                    {
                        context.MapPoints.Add(point);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HikingApi.Model.Interfaces;
using HikingApi.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HikingApi.Controllers
{
    [Route("api/trails")]
    public class TrailController : Controller
    {
        public ITrailRepository Trails { get; set; }
        public TrailController(ITrailRepository trails)
        {
            Trails = trails;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Trail trail)
        {
            if (trail == null)
            {
                return BadRequest();
            }
            Trails.Add(trail);
            return Created("asd", trail);
            //return CreatedAtRoute("getbyid", new { id = trail.Key }, trail);
        }

        [HttpPut("{id}")]
        [Route("update")]
        public IActionResult Update(string id, [FromBody] Trail trail)
        {
            if (trail == null || trail.Key != id)
            {
                return BadRequest();
            }

            var todo = Trails.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            if (!Trails.Update(trail))
            {
                return BadRequest();
            }
            return new NoContentResult();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(Trails.GetAll());
        }

        [HttpGet("{id}")]
        [Route("getbyid")]
        public IActionResult GetById(string id)
        {
            var trail = Trails.Find(id);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpGet("{latitude},{longitude}")]
        [Route("getbycoordinates")]
        public IActionResult GetNear(double latitude, double longitude)
        {
            var trail = Trails.GetNear(latitude, longitude);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpPost]
        [Route("getneartrail")]
        public IActionResult GetNear([FromBody] Trail t)
        {
            var trail = Trails.GetNear(t);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpPost]
        [Route("getnearpoint")]
        public IActionResult GetNear([FromBody] MapPoint point)
        {
            var trail = Trails.GetNear(point);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpDelete]
        [Route("removetrail")]
        public IActionResult Remove([FromBody] Trail t)
        {
            var trail = Trails.Remove(t);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpDelete("{id}")]
        [Route("removetrailbyid")]
        public IActionResult Remove(string id)
        {
            var trail = Trails.Remove(id);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }
    }
}

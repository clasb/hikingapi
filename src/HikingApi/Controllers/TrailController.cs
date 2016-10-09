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
        public async Task<IActionResult> Create([FromBody] Trail trail)
        {
            if (trail == null)
            {
                return BadRequest();
            }
            await Trails.Add(trail);
            //return Created("asd", trail);
            return CreatedAtRoute("getbyid", new { id = trail.TrailId }, trail);
        }

        [HttpPut("{id}")]
        [Route("update")]
        public async Task<IActionResult> Update(string id, [FromBody] Trail trail)
        {
            //TODO: Is this thread safe?! Two awaits in one method..
            if (trail == null || trail.TrailId != id)
            {
                return BadRequest();
            }

            var todo = await Trails.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            var updated = await Trails.Update(trail);
            if (!updated)
            {
                return BadRequest();
            }
            return new NoContentResult();
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Trails.GetAll());
        }

        [HttpGet("{id}", Name = "getbyid")]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var trail = await Trails.Find(id);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpGet("{latitude},{longitude}")]
        [Route("getbycoordinates")]
        public async Task<IActionResult> GetNear(double latitude, double longitude)
        {
            var trail = await Trails.GetNear(latitude, longitude);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpPost]
        [Route("getneartrail")]
        public async Task<IActionResult> GetNear([FromBody] Trail t)
        {
            var trail = await Trails.GetNear(t);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpPost]
        [Route("getnearpoint")]
        public async Task<IActionResult> GetNear([FromBody] MapPoint point)
        {
            var trail = await Trails.GetNear(point);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpDelete]
        [Route("removetrail")]
        public async Task<IActionResult> Remove([FromBody] Trail t)
        {
            var trail = await Trails.Remove(t);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }

        [HttpDelete("{id}")]
        [Route("removetrailbyid")]
        public async Task<IActionResult> Remove(string id)
        {
            var trail = await Trails.Remove(id);
            if (trail == null)
            {
                return NotFound();
            }
            return Ok(trail);
        }
    }
}

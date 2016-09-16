﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Event.Models;

namespace Event.Api.Controllers
{
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        private EventSystemContext db = new EventSystemContext();



        [Route("search")]
        [HttpGet]
        public List<Events> SearchEvents(string name, string categories = "")
        { 
            string[] catIds = {};
            if (categories != "") { 
             catIds = categories.Split(',');
            }

            var data = db.Events.Where(
                p => p.Name.Contains(name) || 
                p.Description.Contains(name) && 
                catIds.Contains(p.FK_Category.ToString())
            ).ToList();

            return data;
        }
        // GET: api/Events
        public List<Events> GetEvents()
        {
            
            var data = db.Events
                .Include(p => p.Categories)
                .Include(p => p.Location)
                .Include(p => p.Media)
                .ToList();

            return data;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Events))]
        public IHttpActionResult GetEvents(int id)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvents(int id, Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != events.Id)
            {
                return BadRequest();
            }

            db.Entry(events).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Events
        [ResponseType(typeof(Events))]
        public IHttpActionResult PostEvents(Events events)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(events);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = events.Id }, events);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Events))]
        public IHttpActionResult DeleteEvents(int id)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                return NotFound();
            }

            db.Events.Remove(events);
            db.SaveChanges();

            return Ok(events);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventsExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}
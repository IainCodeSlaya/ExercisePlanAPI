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
using EPAPII.Models;

namespace EPAPII.Controllers
{
    public class DaysController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/Days
        public IQueryable<Day> GetDays()
        {
            return db.Days;
        }

        // GET: api/Days/5
        [ResponseType(typeof(Day))]
        public IHttpActionResult GetDay(int id)
        {
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return NotFound();
            }

            return Ok(day);
        }

        // PUT: api/Days/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDay(int id, Day day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != day.Day_ID)
            {
                return BadRequest();
            }

            db.Entry(day).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
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

        // POST: api/Days
        [ResponseType(typeof(Day))]
        public IHttpActionResult PostDay(Day day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Days.Add(day);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = day.Day_ID }, day);
        }

        // DELETE: api/Days/5
        [ResponseType(typeof(Day))]
        public IHttpActionResult DeleteDay(int id)
        {
            Day day = db.Days.Find(id);
            if (day == null)
            {
                return NotFound();
            }

            db.Days.Remove(day);
            db.SaveChanges();

            return Ok(day);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DayExists(int id)
        {
            return db.Days.Count(e => e.Day_ID == id) > 0;
        }
    }
}
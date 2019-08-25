using System;
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
    public class DayWorkoutController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/DayWorkout
        public IQueryable<Day_Workout> GetDay_Workout()
        {
            return db.Day_Workout;
        }

        // GET: api/DayWorkout/5
        [ResponseType(typeof(Day_Workout))]
        public IHttpActionResult GetDay_Workout(int id)
        {
            Day_Workout day_Workout = db.Day_Workout.Find(id);
            if (day_Workout == null)
            {
                return NotFound();
            }

            return Ok(day_Workout);
        }

        // PUT: api/DayWorkout/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDay_Workout(int id, Day_Workout day_Workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != day_Workout.Day_Workout_ID)
            {
                return BadRequest();
            }

            db.Entry(day_Workout).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Day_WorkoutExists(id))
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

        // POST: api/DayWorkout
        [ResponseType(typeof(Day_Workout))]
        public IHttpActionResult PostDay_Workout(Day_Workout day_Workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Day_Workout.Add(day_Workout);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = day_Workout.Day_Workout_ID }, day_Workout);
        }

        // DELETE: api/DayWorkout/5
        [ResponseType(typeof(Day_Workout))]
        public IHttpActionResult DeleteDay_Workout(int id)
        {
            Day_Workout day_Workout = db.Day_Workout.Find(id);
            if (day_Workout == null)
            {
                return NotFound();
            }

            db.Day_Workout.Remove(day_Workout);
            db.SaveChanges();

            return Ok(day_Workout);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Day_WorkoutExists(int id)
        {
            return db.Day_Workout.Count(e => e.Day_Workout_ID == id) > 0;
        }
    }
}
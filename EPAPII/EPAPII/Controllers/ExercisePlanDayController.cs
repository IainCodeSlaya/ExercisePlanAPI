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
    public class ExercisePlanDayController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/ExercisePlanDay
        public IQueryable<Exercise_Plan_Day> GetExercise_Plan_Day()
        {
            return db.Exercise_Plan_Day;
        }

        // GET: api/ExercisePlanDay/5
        [ResponseType(typeof(Exercise_Plan_Day))]
        public IHttpActionResult GetExercise_Plan_Day(int id)
        {
            Exercise_Plan_Day exercise_Plan_Day = db.Exercise_Plan_Day.Find(id);
            if (exercise_Plan_Day == null)
            {
                return NotFound();
            }

            return Ok(exercise_Plan_Day);
        }

        // PUT: api/ExercisePlanDay/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Plan_Day(int id, Exercise_Plan_Day exercise_Plan_Day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Plan_Day.Exercise_Plan_Day_ID)
            {
                return BadRequest();
            }

            db.Entry(exercise_Plan_Day).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_Plan_DayExists(id))
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

        // POST: api/ExercisePlanDay
        [ResponseType(typeof(Exercise_Plan_Day))]
        public IHttpActionResult PostExercise_Plan_Day(Exercise_Plan_Day exercise_Plan_Day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise_Plan_Day.Add(exercise_Plan_Day);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise_Plan_Day.Exercise_Plan_Day_ID }, exercise_Plan_Day);
        }

        // DELETE: api/ExercisePlanDay/5
        [ResponseType(typeof(Exercise_Plan_Day))]
        public IHttpActionResult DeleteExercise_Plan_Day(int id)
        {
            Exercise_Plan_Day exercise_Plan_Day = db.Exercise_Plan_Day.Find(id);
            if (exercise_Plan_Day == null)
            {
                return NotFound();
            }

            db.Exercise_Plan_Day.Remove(exercise_Plan_Day);
            db.SaveChanges();

            return Ok(exercise_Plan_Day);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_Plan_DayExists(int id)
        {
            return db.Exercise_Plan_Day.Count(e => e.Exercise_Plan_Day_ID == id) > 0;
        }
    }
}
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
    public class WorkoutSetController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/WorkoutSet
        public IQueryable<Workout_Set> GetWorkout_Set()
        {
            return db.Workout_Set;
        }

        // GET: api/WorkoutSet/5
        [ResponseType(typeof(Workout_Set))]
        public IHttpActionResult GetWorkout_Set(int id)
        {
            Workout_Set workout_Set = db.Workout_Set.Find(id);
            if (workout_Set == null)
            {
                return NotFound();
            }

            return Ok(workout_Set);
        }

        // PUT: api/WorkoutSet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkout_Set(int id, Workout_Set workout_Set)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workout_Set.Workout_Set_ID)
            {
                return BadRequest();
            }

            db.Entry(workout_Set).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Workout_SetExists(id))
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

        // POST: api/WorkoutSet
        [ResponseType(typeof(Workout_Set))]
        public IHttpActionResult PostWorkout_Set(Workout_Set workout_Set)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workout_Set.Add(workout_Set);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workout_Set.Workout_Set_ID }, workout_Set);
        }

        // DELETE: api/WorkoutSet/5
        [ResponseType(typeof(Workout_Set))]
        public IHttpActionResult DeleteWorkout_Set(int id)
        {
            Workout_Set workout_Set = db.Workout_Set.Find(id);
            if (workout_Set == null)
            {
                return NotFound();
            }

            db.Workout_Set.Remove(workout_Set);
            db.SaveChanges();

            return Ok(workout_Set);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Workout_SetExists(int id)
        {
            return db.Workout_Set.Count(e => e.Workout_Set_ID == id) > 0;
        }
    }
}
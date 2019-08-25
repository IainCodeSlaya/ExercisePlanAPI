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
    public class ExerciseSetController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/ExerciseSet
        public IQueryable<Exercise_Set> GetExercise_Set()
        {
            return db.Exercise_Set;
        }

        // GET: api/ExerciseSet/5
        [ResponseType(typeof(Exercise_Set))]
        public IHttpActionResult GetExercise_Set(int id)
        {
            Exercise_Set exercise_Set = db.Exercise_Set.Find(id);
            if (exercise_Set == null)
            {
                return NotFound();
            }

            return Ok(exercise_Set);
        }

        // PUT: api/ExerciseSet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Set(int id, Exercise_Set exercise_Set)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Set.Exercise_Set_ID)
            {
                return BadRequest();
            }

            db.Entry(exercise_Set).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_SetExists(id))
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

        // POST: api/ExerciseSet
        [ResponseType(typeof(Exercise_Set))]
        public IHttpActionResult PostExercise_Set(Exercise_Set exercise_Set)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise_Set.Add(exercise_Set);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise_Set.Exercise_Set_ID }, exercise_Set);
        }

        // DELETE: api/ExerciseSet/5
        [ResponseType(typeof(Exercise_Set))]
        public IHttpActionResult DeleteExercise_Set(int id)
        {
            Exercise_Set exercise_Set = db.Exercise_Set.Find(id);
            if (exercise_Set == null)
            {
                return NotFound();
            }

            db.Exercise_Set.Remove(exercise_Set);
            db.SaveChanges();

            return Ok(exercise_Set);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_SetExists(int id)
        {
            return db.Exercise_Set.Count(e => e.Exercise_Set_ID == id) > 0;
        }
    }
}
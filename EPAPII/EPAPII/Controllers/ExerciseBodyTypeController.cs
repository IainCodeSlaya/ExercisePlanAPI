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
    public class ExerciseBodyTypeController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/ExerciseBodyType
        public IQueryable<Exercise_Body_Type> GetExercise_Body_Type()
        {
            return db.Exercise_Body_Type;
        }

        // GET: api/ExerciseBodyType/5
        [ResponseType(typeof(Exercise_Body_Type))]
        public IHttpActionResult GetExercise_Body_Type(int id)
        {
            Exercise_Body_Type exercise_Body_Type = db.Exercise_Body_Type.Find(id);
            if (exercise_Body_Type == null)
            {
                return NotFound();
            }

            return Ok(exercise_Body_Type);
        }

        // PUT: api/ExerciseBodyType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Body_Type(int id, Exercise_Body_Type exercise_Body_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Body_Type.Exercise_Body_Type_ID)
            {
                return BadRequest();
            }

            db.Entry(exercise_Body_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_Body_TypeExists(id))
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

        // POST: api/ExerciseBodyType
        [ResponseType(typeof(Exercise_Body_Type))]
        public IHttpActionResult PostExercise_Body_Type(Exercise_Body_Type exercise_Body_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise_Body_Type.Add(exercise_Body_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise_Body_Type.Exercise_Body_Type_ID }, exercise_Body_Type);
        }

        // DELETE: api/ExerciseBodyType/5
        [ResponseType(typeof(Exercise_Body_Type))]
        public IHttpActionResult DeleteExercise_Body_Type(int id)
        {
            Exercise_Body_Type exercise_Body_Type = db.Exercise_Body_Type.Find(id);
            if (exercise_Body_Type == null)
            {
                return NotFound();
            }

            db.Exercise_Body_Type.Remove(exercise_Body_Type);
            db.SaveChanges();

            return Ok(exercise_Body_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_Body_TypeExists(int id)
        {
            return db.Exercise_Body_Type.Count(e => e.Exercise_Body_Type_ID == id) > 0;
        }
    }
}
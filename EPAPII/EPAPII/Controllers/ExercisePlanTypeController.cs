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
    public class ExercisePlanTypeController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/ExercisePlanType
        public IQueryable<Exercise_Plan_Type> GetExercise_Plan_Type()
        {
            return db.Exercise_Plan_Type;
        }

        // GET: api/ExercisePlanType/5
        [ResponseType(typeof(Exercise_Plan_Type))]
        public IHttpActionResult GetExercise_Plan_Type(int id)
        {
            Exercise_Plan_Type exercise_Plan_Type = db.Exercise_Plan_Type.Find(id);
            if (exercise_Plan_Type == null)
            {
                return NotFound();
            }

            return Ok(exercise_Plan_Type);
        }

        // PUT: api/ExercisePlanType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Plan_Type(int id, Exercise_Plan_Type exercise_Plan_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Plan_Type.Exercise_Plan_Type_ID)
            {
                return BadRequest();
            }

            db.Entry(exercise_Plan_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_Plan_TypeExists(id))
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

        // POST: api/ExercisePlanType
        [ResponseType(typeof(Exercise_Plan_Type))]
        public IHttpActionResult PostExercise_Plan_Type(Exercise_Plan_Type exercise_Plan_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercise_Plan_Type.Add(exercise_Plan_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercise_Plan_Type.Exercise_Plan_Type_ID }, exercise_Plan_Type);
        }

        // DELETE: api/ExercisePlanType/5
        [ResponseType(typeof(Exercise_Plan_Type))]
        public IHttpActionResult DeleteExercise_Plan_Type(int id)
        {
            Exercise_Plan_Type exercise_Plan_Type = db.Exercise_Plan_Type.Find(id);
            if (exercise_Plan_Type == null)
            {
                return NotFound();
            }

            db.Exercise_Plan_Type.Remove(exercise_Plan_Type);
            db.SaveChanges();

            return Ok(exercise_Plan_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_Plan_TypeExists(int id)
        {
            return db.Exercise_Plan_Type.Count(e => e.Exercise_Plan_Type_ID == id) > 0;
        }
    }
}
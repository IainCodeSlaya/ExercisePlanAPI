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
    public class ExercisePlanController : ApiController
    {
        private ExercisePlanDBEntities db = new ExercisePlanDBEntities();

        // GET: api/ExercisePlan
        public IQueryable<Exercise_Plan> GetExercise_Plan()
        {
            return db.Exercise_Plan;
        }

        // GET: api/ExercisePlan/5
        [ResponseType(typeof(Exercise_Plan))]
        public IHttpActionResult GetExercise_Plan(int id)
        {
            Exercise_Plan exercise_Plan = db.Exercise_Plan.Find(id);
            if (exercise_Plan == null)
            {
                return NotFound();
            }

            return Ok(exercise_Plan);
        }

        // PUT: api/ExercisePlan/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercise_Plan(int id, Exercise_Plan exercise_Plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise_Plan.Exercise_Plan_ID)
            {
                return BadRequest();
            }

            db.Entry(exercise_Plan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exercise_PlanExists(id))
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

        // POST: api/ExercisePlan
        [ResponseType(typeof(Exercise_Plan))]
        public IHttpActionResult PostExercise_Plan(Exercise_Plan exercise_Plan)
        {
            try
            {
                //exercise plan table
                db.Exercise_Plan.Add(exercise_Plan);

                //exercise plan day tavle
                foreach (var item in exercise_Plan.Exercise_Plan_Day)
                {
                    db.Exercise_Plan_Day.Add(item);
                }
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/ExercisePlan/5
        [ResponseType(typeof(Exercise_Plan))]
        public IHttpActionResult DeleteExercise_Plan(int id)
        {
            Exercise_Plan exercise_Plan = db.Exercise_Plan.Find(id);
            if (exercise_Plan == null)
            {
                return NotFound();
            }

            db.Exercise_Plan.Remove(exercise_Plan);
            db.SaveChanges();

            return Ok(exercise_Plan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exercise_PlanExists(int id)
        {
            return db.Exercise_Plan.Count(e => e.Exercise_Plan_ID == id) > 0;
        }
    }
}
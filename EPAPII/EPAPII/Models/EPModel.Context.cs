﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPAPII.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExercisePlanDBEntities : DbContext
    {
        public ExercisePlanDBEntities()
            : base("name=ExercisePlanDBEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Day_Workout> Day_Workout { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Exercise_Body_Type> Exercise_Body_Type { get; set; }
        public virtual DbSet<Exercise_Plan> Exercise_Plan { get; set; }
        public virtual DbSet<Exercise_Plan_Day> Exercise_Plan_Day { get; set; }
        public virtual DbSet<Exercise_Plan_Type> Exercise_Plan_Type { get; set; }
        public virtual DbSet<Exercise_Set> Exercise_Set { get; set; }
        public virtual DbSet<Exercise_Type> Exercise_Type { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<Workout_Set> Workout_Set { get; set; }
    }
}

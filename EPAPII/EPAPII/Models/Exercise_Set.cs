//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Exercise_Set
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise_Set()
        {
            this.Workout_Set = new HashSet<Workout_Set>();
        }
    
        public int Exercise_Set_ID { get; set; }
        public string REP { get; set; }
        public int Exercise_ID { get; set; }
        public int Set_ID { get; set; }
    
        public virtual Exercise Exercise { get; set; }
        public virtual Set Set { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workout_Set> Workout_Set { get; set; }
    }
}

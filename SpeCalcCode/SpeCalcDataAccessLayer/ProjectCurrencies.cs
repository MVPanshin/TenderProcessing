//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpeCalcDataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectCurrencies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectCurrencies()
        {
            this.ProjectPositionCalculations = new HashSet<ProjectPositionCalculations>();
            this.ProjectPositionCalculations1 = new HashSet<ProjectPositionCalculations>();
            this.Projects = new HashSet<Projects>();
            this.ProjectWorkCalculations = new HashSet<ProjectWorkCalculations>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectPositionCalculations> ProjectPositionCalculations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectPositionCalculations> ProjectPositionCalculations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectWorkCalculations> ProjectWorkCalculations { get; set; }
    }
}

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
    
    public partial class ProjectSaleDirections
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectSaleDirections()
        {
            this.Projects = new HashSet<Projects>();
            this.ProjectSaleDirectionResponsibles = new HashSet<ProjectSaleDirectionResponsibles>();
            this.ProjectSaleSubjects = new HashSet<ProjectSaleSubjects>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNum { get; set; }
        public string SysName { get; set; }
        public bool Enabled { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects> Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSaleDirectionResponsibles> ProjectSaleDirectionResponsibles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectSaleSubjects> ProjectSaleSubjects { get; set; }
    }
}

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
    
    public partial class ProjectPositionStates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectPositionStates()
        {
            this.ProjectPositions = new HashSet<ProjectPositions>();
            this.ProjectPositionStateHistory = new HashSet<ProjectPositionStateHistory>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string SysName { get; set; }
        public bool Enabled { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectPositions> ProjectPositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectPositionStateHistory> ProjectPositionStateHistory { get; set; }
    }
}

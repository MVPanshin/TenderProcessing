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
    
    public partial class ProjectStateHistory
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatorSid { get; set; }
        public string CreatorName { get; set; }
        public string Comment { get; set; }
        public string FileSid { get; set; }
        public int ProjectId { get; set; }
    
        public virtual Projects Projects { get; set; }
        public virtual ProjectStates ProjectStates { get; set; }
    }
}
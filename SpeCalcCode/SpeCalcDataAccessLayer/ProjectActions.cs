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
    
    public partial class ProjectActions
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatorSid { get; set; }
        public string CreatorName { get; set; }
        public Nullable<System.DateTime> NoticeDate { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleSid { get; set; }
        public bool Done { get; set; }
        public int ProjectId { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string DeleterSid { get; set; }
        public string DeleterName { get; set; }
        public Nullable<System.DateTime> DoneDate { get; set; }
        public string DoneSetterSid { get; set; }
        public string DoneSetterName { get; set; }
    
        public virtual Projects Projects { get; set; }
    }
}

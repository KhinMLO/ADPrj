//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicUniversity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requisition
    {
        public Requisition()
        {
            this.RequisitionItems = new HashSet<RequisitionItem>();
        }
    
        public int RequisitionID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<RequisitionItem> RequisitionItems { get; set; }
    }
}
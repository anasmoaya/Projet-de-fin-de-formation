//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projet_de_fin_de_formation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Congee
    {
        [Key]

        public int IdConge { get; set; }
        public string IdEmp { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    
        public virtual EmployeeTable EmployeeTable { get; set; }
    }
}
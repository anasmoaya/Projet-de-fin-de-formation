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
    
    public partial class reclamation
    {
        public Nullable<int> idClient { get; set; }
        public Nullable<int> idChantier { get; set; }
        public Nullable<System.DateTime> dateRec { get; set; }
        public string Remarque { get; set; }
        public int idReclamation { get; set; }
    
        public virtual Chantier Chantier { get; set; }
        public virtual Client Client { get; set; }
    }
}

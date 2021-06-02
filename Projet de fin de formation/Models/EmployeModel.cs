using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_de_fin_de_formation.Models
{
    public class EmployeModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string  Email { get; set; }
        public DateTime Date_naissance { get; set; }
        public DateTime DateEmploi { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public string departement { get; set; }
        public string Grade { get; set; }

    }
}
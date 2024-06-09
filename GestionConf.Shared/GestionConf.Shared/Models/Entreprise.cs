using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Entreprise
    {
        [Key]
        public int IdEntreprise { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Auteur> Auteurs { get; set; }
    }
}

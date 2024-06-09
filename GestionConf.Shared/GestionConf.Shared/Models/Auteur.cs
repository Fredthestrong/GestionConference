using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Auteur
    {
        [Key]
        public int IdAuteur { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Email { get; set; }

        public string Université { get; set; }
        public string Entreprise { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}

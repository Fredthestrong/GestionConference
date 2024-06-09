using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Article
    {
        [Key]
        public int IdArticle { get; set; }

        [Required]
        public string Titre { get; set; }

        public string Description { get; set; }

        [Required]
        public string FichierPDF { get; set; }

        [ForeignKey("AuteurCorrespondant")]
        public int AuteurCorrespondantId { get; set; }
        public Auteur AuteurCorrespondant { get; set; }

        [ForeignKey("Conférence")]
        public int IdConférence { get; set; }
        public Conférence Conférence { get; set; }

        public ICollection<Auteur> CoAuteurs { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Evaluation
    {
        [Key]
        public int IdEvaluation { get; set; }

        [Required]
        public string Fond { get; set; }

        [Required]
        public string Forme { get; set; }

        [Required]
        public string PertinenceScientifique { get; set; }

        [ForeignKey("Relecteur")]
        public int IdRelecteur { get; set; }
        public Relecteur Relecteur { get; set; }

        [ForeignKey("Article")]
        public int IdArticle { get; set; }
        public Article Article { get; set; }
    }
}

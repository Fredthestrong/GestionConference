using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Conférence
    {
        [Key]
        public int IdConférence { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Sigle { get; set; }

        [Required]
        public string Thème { get; set; }

        public DateTime DateDébutSoumission { get; set; }
        public DateTime DateFinSoumission { get; set; }
        public DateTime DateRemiseRésultats { get; set; }
        public DateTime DateInscription { get; set; }
        public DateTime DateDéroulement { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}

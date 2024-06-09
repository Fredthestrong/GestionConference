using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.Models
{
    public class Participant
    {
        [Key]
        public int IdParticipant { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Conférence> Conférences { get; set; }
    }
}

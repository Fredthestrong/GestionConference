using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.ModelsDto
{
    public class AuteurDto
    {
        public int IdAuteur { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Université { get; set; }
        public string Entreprise { get; set; }
    }
}

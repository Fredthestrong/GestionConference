using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.ModelsDto
{
    public class ConférenceDto
    {
        public int IdConférence { get; set; }
        public string Nom { get; set; }
        public string Sigle { get; set; }
        public string Thème { get; set; }
        public DateTime DateDébutSoumission { get; set; }
        public DateTime DateFinSoumission { get; set; }
        public DateTime DateRemiseRésultats { get; set; }
        public DateTime DateInscription { get; set; }
        public DateTime DateDéroulement { get; set; }
    }
}

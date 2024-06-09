using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConf.Shared.ModelsDto
{
    public class ArticleDto
    {
        public int IdArticle { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string FichierPDF { get; set; }
        public int AuteurCorrespondantId { get; set; }
        public int IdConférence { get; set; }
    }
}

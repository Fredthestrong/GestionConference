using AutoMapper;
using GestionConf.Shared.Models;
using GestionConf.Shared.ModelsDto;

namespace GestionConf.server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Administrateur, AdministrateurDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Auteur, AuteurDto>().ReverseMap();
            CreateMap<Conférence, ConférenceDto>().ReverseMap();
            CreateMap<Entreprise, EntrepriseDto>().ReverseMap();
            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<Relecteur, RelecteurDto>().ReverseMap();
            CreateMap<Evaluation, EvaluationDto>().ReverseMap();
            CreateMap<Université, UniversitéDto>().ReverseMap();


        }
    }
}


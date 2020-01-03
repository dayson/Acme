using Acme.Data.Entities;
using Acme.ViewModels;
using AutoMapper;

namespace Acme.Data
{
    public class AcmeMappingProfile : Profile
    {
        public AcmeMappingProfile()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
        }
    }
}

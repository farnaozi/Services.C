using AutoMapper;
using Services.C.Core.Dtos;
using Services.C.Core.Models;

namespace Services.C.Core.Profiles
{
    public class TemplateServiceProfiles : Profile
    {
        public TemplateServiceProfiles()
        {
            // source --> target
            //CreateMap<ServiceTemplateShortInfo, ServiceTemplateRead>();
            //CreateMap<ServiceTemplateFullInfo, ServiceTemplateByIdRead>();
            //CreateMap<ServiceTemplateCreate, ServiceTemplateFullInfo>();
        }
    }
}
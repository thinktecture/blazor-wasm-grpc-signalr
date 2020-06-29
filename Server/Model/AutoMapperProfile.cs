using AutoMapper;

namespace ConfTool.Server.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model.Conference, ConfTool.Shared.DTO.ConferenceOverview>();
            CreateMap<ConfTool.Shared.DTO.ConferenceOverview, Model.Conference>();
            CreateMap<Model.Conference, ConfTool.Shared.DTO.ConferenceDetails>();
            CreateMap<ConfTool.Shared.DTO.ConferenceDetails, Model.Conference>();
        }
    }
}

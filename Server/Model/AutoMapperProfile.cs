using AutoMapper;
using Conference;

namespace ConfTool.Server.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Model.Conference, ConferenceOverview>();
            CreateMap<ConferenceOverview, Model.Conference>();

            CreateMap<Model.Conference, ConfTool.Shared.DTO.ConferenceDetails>();
            CreateMap<Model.Conference, ConfTool.Shared.DTO.ConferenceOverview>();
            CreateMap<ConfTool.Shared.DTO.ConferenceDetails, Model.Conference>();
            CreateMap<ConfTool.Shared.DTO.ConferenceOverview, Model.Conference>();
        }
    }
}

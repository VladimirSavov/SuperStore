namespace SuperStore.Infrastructure.Profiles
{
    using AutoMapper;
    using SuperStore.Data.Models;
    using SuperStore.Services.Answers.Models;

    using static ProfileConstants;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            this.CreateMap<Answer, AnswerServiceModel>()
                .ForMember(x => x.UserName, cfg => cfg.MapFrom(x => x.User.FullName))
                .ForMember(x => x.PublishedOn, cfg => cfg.MapFrom(x => x.PublishedOn.ToString(DateTimeFormat)));





        }


    }
}

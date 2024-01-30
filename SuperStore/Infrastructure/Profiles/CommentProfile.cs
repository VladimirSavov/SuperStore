namespace SuperStore.Infrastructure.Profiles
{
    using AutoMapper;
    using SuperStore.Data.Models;
    using SuperStore.Services.Comments.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ProfileConstants;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            this.CreateMap<Comment, CommentServiceModel>()
                .ForMember(x => x.UserName, cfg => cfg.MapFrom(x => x.User.FullName))
                .ForMember(x => x.PublishedOn, cfg => cfg.MapFrom(x => x.PublishedOn.ToString(DateTimeFormat)));

        }

    }
}

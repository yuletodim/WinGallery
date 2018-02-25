namespace WinGallery.Services.Models.RewardStrategies
{
    using AutoMapper;
    using System;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;

    public class RewardStrategyModel : IMapFrom<RewardStrategy>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPrizes { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int ContestsCount { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<RewardStrategy, RewardStrategyModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(x => x.ContestsCount, opt => opt.MapFrom(x => x.Contests.Count));
        }
    }
}

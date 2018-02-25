namespace WinGallery.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using AutoMapper;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Mappings;
    using System.Linq;

    public class ContestModel : IMapFrom<Contest>, IMapTo<Contest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RewardStrategyId { get; set; }

        public string RewardStrategyName { get; set; }

        public VotingStrategy VotingStrategy { get; set; }

        public ParticipationStrategy ParticipationStrategy { get; set; }

        public PictureModel MostVotedPicture { get; set; }

        public DeadlineStrategy DeadlineStrategy { get; set; }

        public virtual IEnumerable<PictureModel> Pictures { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Contest, ContestModel>()
                .ForMember(c => c.MostVotedPicture, opt => opt.MapFrom(x => x.Pictures.OrderBy(p => p.Votes).FirstOrDefault()));
        }

        public static Expression<Func<Contest, ContestModel>> Map
        {
            get
            {
                return c => new ContestModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    RewardStrategyId = c.RewardStrategyId,
                    VotingStrategy = c.VotingStrategy,
                    ParticipationStrategy = c.ParticipationStrategy,
                    DeadlineStrategy = c.DeadlineStrategy                  
                };
            }
        }
    }
}

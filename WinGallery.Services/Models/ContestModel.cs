using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using WinGallery.DATA.Models;
using WinGallery.Services.Mappings;

namespace WinGallery.Services.Models
{
    public class ContestModel : IMapFrom<Contest>, IMapTo<Contest>, IHaveCustomMappings
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RewardStrategyID { get; set; }

        public string RewardStrategyName { get; set; }

        public int VotingStrategyID { get; set; }

        public string VotingStrategyName { get; set; }

        public int ParticipationStrategyID { get; set; }

        public string ParticipationStrategyName { get; set; }

        public PictureModel MostVotedPicture { get; set; }

        public int DeadlineStrategyID { get; set; }

        public string DeadlineStrategyName { get; set; }

        public virtual IEnumerable<PictureModel> Pictures { get; set; }

        public static Expression<Func<Contest, ContestModel>> Map
        {
            get
            {
                return c => new ContestModel
                {
                    ID = c.ID,
                    Title = c.Title,
                    Description = c.Description,
                    RewardStrategyID = c.RewardStrategyID,
                    VotingStrategyID = c.VotingStrategyID,
                    ParticipationStrategyID = c.ParticipationStrategyID,
                    DeadlineStrategyID = c.DeadlineStrategyID                  
                };
            }
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Contest, ContestModel>()
                .ForMember(x => x.RewardStrategyName, opt => opt.MapFrom(x => x.RewardStrategy.Name))
                .ForMember(x => x.VotingStrategyName, opt => opt.MapFrom(x => x.VotingStrategy.Name))
                .ForMember(x => x.ParticipationStrategyName, opt => opt.MapFrom(x => x.VotingStrategy.Name))
                .ForMember(x => x.DeadlineStrategyName, opt => opt.MapFrom(x => x.DeadlineStrategy.Name));
        }
    }
}

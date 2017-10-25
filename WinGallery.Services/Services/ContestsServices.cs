namespace WinGallery.Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using WinGallery.DATA.Models;
    using WinGallery.DATA.Repositories;
    using WinGallery.Services.Interfaces;
    using Mappings;
    using Models;
    using Services;

    public class ContestsServices : BaseServices, IContestsServices
    {
        private readonly IDbRepository<Contest, int> contestsRepository;

        public ContestsServices(IDbRepository<Contest, int> contestsRepository)
        {
            this.contestsRepository = contestsRepository;
        }

        public IEnumerable<ContestModel> GetAll()
        {
            var contests = this.contestsRepository
                .GetAll()
                .ProjectTo<ContestModel>(AutoMapperConfig.Configuration)
                .ToList();

            foreach (var contest in contests)
            {
                var pic = contest.Pictures.OrderByDescending(x => x.Votes).FirstOrDefault();
                contest.MostVotedPicture = pic;
            }

            return contests;
        }

        public ContestModel GetById(int id)
        {
            var contest = this.contestsRepository.Find(id);
            var contestModel = this.Mapper.Map<ContestModel>(contest);

            return contestModel;
        }
    }


}

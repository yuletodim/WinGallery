namespace WinGallery.Services.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using WinGallery.DATA.Models;
    using WinGallery.DATA.Repositories;
    using WinGallery.Services.Interfaces;
    using Models;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using WinGallery.Services.Mappings;

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
                .To<ContestModel>()
                .ToList();

            return contests;
        }

        public async Task<ContestModel> GetById(int id)
        {
            var contest = this.contestsRepository.Find(id);
            var contestModel = this.Mapper.Map<ContestModel>(contest);

            var model = await this.contestsRepository
                .GetAll()
                .Where(contestsRepository => contestsRepository.Id == id)
                .ProjectTo<ContestModel>()
                .FirstOrDefaultAsync();

            return contestModel;
        }
    }


}

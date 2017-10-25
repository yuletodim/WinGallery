namespace WinGallery.Services.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using WinGallery.DATA.Models;
    using WinGallery.Services.Interfaces;
    using DATA.Repositories;
    using Mappings;
    using Microsoft.AspNet.Identity;
    using Models;

    public class UsersServices : BaseServices, IUsersServices
    {
        private readonly UserManager<User> userManager;
        private readonly IDbRepository<User, string> usersRepository;

        public UsersServices(UserManager<User> userManager, IDbRepository<User, string> usersRepository)
        {
            this.userManager = userManager;
            this.usersRepository = usersRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var users = this.usersRepository
                .GetAll()
                .ProjectTo<UserModel>(AutoMapperConfig.Configuration)
                .ToList();

            return users;
        }

        public UserModel GetById(string id)
        {
            var user = this.usersRepository.Find(id);
            var userModel = this.Mapper.Map<UserModel>(user);

            return userModel;
        }
    }
}

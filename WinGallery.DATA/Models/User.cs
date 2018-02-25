namespace WinGallery.DATA.Models
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CommonLogic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }       

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();

        public ICollection<Contest> Contests { get; set; } = new HashSet<Contest>();

        public ICollection<RewardStrategy> RewardStrategys { get; set; } = new HashSet<RewardStrategy>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

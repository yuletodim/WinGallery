namespace WinGallery.DATA.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CommonLogic;

    public class ParticipationStrategy : BaseModel
    {
        public ParticipationStrategy()
        {
            this.Contests = new HashSet<Contest>();
        }

        [Key]
        public int ID { get; set; }

        public string name { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}

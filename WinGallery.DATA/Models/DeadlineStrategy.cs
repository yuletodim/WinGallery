namespace WinGallery.DATA.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CommonLogic;

    public class DeadlineStrategy : BaseModel
    {
        public DeadlineStrategy()
        {
            this.Contests = new HashSet<Contest>();
        }

        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}

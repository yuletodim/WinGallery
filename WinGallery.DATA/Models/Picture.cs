namespace WinGallery.DATA.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using CommonLogic;

    public class Picture : BaseModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int Votes { get; set; }

        [ForeignKey("Contest")]
        public int ContestID { get; set; }

        public virtual Contest Contest { get; set; }
    }
}

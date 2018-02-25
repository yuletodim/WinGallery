namespace WinGallery.DATA.Models
{
    using CommonLogic;
    using System.ComponentModel.DataAnnotations;
    using static Common.DataConstants;

    public class Picture : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PictureTitleMinLength, ErrorMessage = PictureTitleErrorMessage)]
        [MaxLength(PictureTitleMaxLength, ErrorMessage = PictureTitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(PictureDescriptionMinLength, ErrorMessage = PictureDescriptionErrorMessage)]
        [MaxLength(PictureDescriptionMaxLength, ErrorMessage = PictureDescriptionErrorMessage)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        public int? Votes { get; set; }

        [Required]
        public int ContestId { get; set; }

        public virtual Contest Contest { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}

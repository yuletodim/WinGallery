namespace WinGallery.DATA.Models.CommonLogic
{
    using System;

    public interface IDeletableEntity
    {
        bool IsDeleted { get; set;  }

        DateTime? DeletedOn { get; set; }
    }
}

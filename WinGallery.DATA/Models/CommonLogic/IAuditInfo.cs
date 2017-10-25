namespace WinGallery.DATA.Models.CommonLogic
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set;  }

        DateTime? ModifiedOn { get; set; }
    }
}

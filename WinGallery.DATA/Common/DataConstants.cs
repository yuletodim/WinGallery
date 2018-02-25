namespace WinGallery.DATA.Common
{
    public class DataConstants
    {
        public const string ModeratorRole = "Moderator";
        public const string AdminRole = "Admin";

        public const int ContestTitleMinLength = 5;
        public const int ContestTitleMaxLength = 255;
        public const string ContestTitleErrorMessage = "Contest name should be between 5 and 255 characters.";

        public const int ContestDescriptionMinLength = 50;
        public const int ContestDescriptionMaxLength = 10000;
        public const string ContestDescriptionErrorMessage = "Contest description should be between 50 and 10000 characters.";

        public const int RewardStrategyNameMinLength = 5;
        public const int RewardStrategyNameMaxLength = 255;
        public const string RewardStrategyNameErrorMessage = "Reward Strategy name should be between 5 and 255 characters.";
        public const string RewardStrategyDescriptionErrorMessage = "Reward Strategy decription should be between up to 255 characters.";

        public const int PictureTitleMinLength = 5;
        public const int PictureTitleMaxLength = 255;
        public const string PictureTitleErrorMessage = "Picture name should be between 5 and 255 characters.";

        public const int PictureDescriptionMinLength = 50;
        public const int PictureDescriptionMaxLength = 10000;
        public const string PictureDescriptionErrorMessage = "Picture description should be between 50 and 10000 characters.";
    }
}

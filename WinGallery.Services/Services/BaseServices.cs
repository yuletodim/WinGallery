namespace WinGallery.Services.Services
{
    using AutoMapper;
    using WinGallery.Services.Mappings;
    using log4net;
    using Utils;

    public abstract class BaseServices
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected ILog Logger
        {
            get
            {
                return AppLogger.logger;
            }
        }
    }
}

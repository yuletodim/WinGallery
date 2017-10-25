namespace WinGallery.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IEmailServices
    {
        Task SendAsync(string email, string emailBody, string emailSubject);
    }
}

using cms_be.Models;

namespace cms_be.HeaderServices
{
    public interface IHeaderService
    {
        Task<Response<bool>> ChangeLogoImage(string fileName);
        Task<Response<bool>> ChangeLogoName(string fileName);
        Task<Response<bool>> ChangePhone(string fileName);
    }
}

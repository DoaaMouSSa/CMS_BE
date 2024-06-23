using cms_be.Models;
using cms_be.Models.HeaderModels;

namespace cms_be.HeaderServices
{
    public interface IHeaderService
    {
        Task<Response<bool>> ChangeLogoImage(int id, string fileName);
        Task<Response<bool>> ChangeLogoName(HeaderDto headerDto);
        Task<Response<bool>> ChangePhone(HeaderDto headerDto);
    }
}

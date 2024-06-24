using cms_be.Models;
using cms_be.Models.ContentModels;
using cms_be.Models.HeaderModels;

namespace cms_be.HeaderServices
{
    public interface IContentService
    {
        Task<Response<bool>> ChangeContent(Content content);
        //Task<Response<Content>> GetContentData();
        Task<Response<Content>> GetHeaderData();
        Task<Response<Content>> GetBannerData();
    }
}

using cms_be.DataContext;
using cms_be.Models;
using cms_be.Models.ContentModels;

namespace cms_be.HeaderServices
{
    public class ContentService : IContentService
    {
        private readonly ApplicationDbContext _context;
        public ContentService(ApplicationDbContext context)
        {
            _context = context;
        }
        private Content findContentType(int contentType)
        {
           return _context.tblContent.Where(c=>c.ContentType== contentType).FirstOrDefault();
        }

        public async Task<Response<bool>> ChangeContent(Content newContent)
        {
            Response<bool> response = new Response<bool>();
            Content content = findContentType(newContent.ContentType);
            content.Heading = newContent.Heading;
            content.Text = newContent.Text;
            content.ImagePath = newContent.ImagePath;
            _context.Update(content);
            _context.SaveChanges();
            response.Payload= true;
            response.Message = "تم التحديث بنجاح";
            response.IsSuccess = true;
            return response;
        }

        public async Task<Response<Content>> GetHeaderContent()
        {
            Response<Content> response = new Response<Content>();
            Content content = findContentType(1);
            content.ImagePath = "http://localhost:4220/Images/Header/" + content.ImagePath;
            if (content !=null)
            {
                response.Payload = content;
                response.Message = "تم تحميل بنجاح";
                response.IsSuccess = true;
            }
           
            return response;
        }
        public async Task<Response<Content>> GetBannerContent()
        {
            Response<Content> response = new Response<Content>();
            Content content = findContentType(2);
            content.ImagePath = "http://localhost:4220/Images/Banner/" + content.ImagePath;
            if (content != null)
            {
                response.Payload = content;
                response.Message = "تم تحميل بنجاح";
                response.IsSuccess = true;
            }

            return response;
        }
        public async Task<Response<Content>> GetHeroContent()
        {
            Response<Content> response = new Response<Content>();
            Content content = findContentType(3);
            content.ImagePath = "http://localhost:4220/Images/Hero/" + content.ImagePath;
            if (content != null)
            {
                response.Payload = content;
                response.Message = "تم تحميل بنجاح";
                response.IsSuccess = true;
            }

            return response;
        }
    }
}

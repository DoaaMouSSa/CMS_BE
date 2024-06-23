using cms_be.DataContext;
using cms_be.Models;
using cms_be.Models.HeaderModels;

namespace cms_be.HeaderServices
{
    public class HeaderService : IHeaderService
    {
        private readonly ApplicationDbContext _context;
        public HeaderService(ApplicationDbContext context)
        {
            _context = context;
        }
        private Header findById(int id)
        {
           return _context.tblHeader.Find(id);
        }

        public async Task<Response<bool>> ChangeLogoImage(int id,string fileName)
        {
            Response<bool> response = new Response<bool>();
            Header header = findById(id);
            header.LogoImage = fileName;
            _context.Update(header);
            _context.SaveChanges();
            response.Payload= true;
            response.Message = "تم التحديث بنجاح";
            response.IsSuccess = true;
            return response;
        }

        public async Task<Response<bool>> ChangeLogoName(HeaderDto headerDto)
        {
            Response<bool> response = new Response<bool>();
            Header header = findById(headerDto.Id);
            header.logoName = headerDto.Data;
            _context.Update(header);
            _context.SaveChanges();
            response.Payload = true;
            response.Message = "تم التحديث بنجاح";
            response.IsSuccess = true;
            return response;
        }

        public async Task<Response<bool>> ChangePhone(HeaderDto headerDto)
        {
            Response<bool> response = new Response<bool>();
            Header header = findById(headerDto.Id);
            header.Phone = headerDto.Data;
            _context.Update(header);
            _context.SaveChanges();
            response.Payload = true;
            response.Message = "تم التحديث بنجاح";
            response.IsSuccess = true;
            return response;
        }

        public async Task<Response<Header>> GetData()
        {
            Response<Header> response = new Response<Header>();
            Header header = findById(1);//type is equal to header in the future work
            header.LogoImage = "http://localhost:4220/Images/Header/" + header.LogoImage;
            if (header !=null)
            {
                response.Payload = header;
                response.Message = "تم تحميل بنجاح";
                response.IsSuccess = true;
            }
           
            return response;
        }
    }
}

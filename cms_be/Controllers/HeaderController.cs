using cms_be.AuthServices;
using cms_be.FileHandling;
using cms_be.HeaderServices;
using cms_be.Models;
using cms_be.Models.HeaderModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cms_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHeaderService _headerService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public HeaderController(IHeaderService headerService, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _headerService = headerService;
            _environment = environment;
        }

        [HttpPost("ChangeLogoImage")]
        public async Task<IActionResult> ChangeLogoImage([FromForm] int id, IFormFile Imagefile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string imagePath = "";
            if (Imagefile != null)
            {
                FileHandler fileHandler = new FileHandler(_environment);
                imagePath = fileHandler.UploadImage(Imagefile, "Header");
            }
            var result = await _headerService.ChangeLogoImage(id,imagePath);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("ChangeLogoName")]
        public async Task<IActionResult> ChangeLogoName([FromBody] HeaderDto headerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _headerService.ChangeLogoName(headerDto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("ChangePhone")]
        public async Task<IActionResult> ChangePhone([FromBody] HeaderDto headerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _headerService.ChangePhone(headerDto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

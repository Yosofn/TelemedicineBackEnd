using BLL.Interfaces;
using BLL.Repositories;
using DAL.DTOS.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Helpers;

namespace Medconnection.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository) {

            _imageRepository = imageRepository;

        }

        [HttpPost("{UserId}")]
        public async Task<IActionResult> AddProfiePricture(int UserId, [FromForm] FileUpload fileUpload, int profileStatus)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    var image = await _imageRepository.SetImage(UserId, fileUpload.files, profileStatus);
                    string path = "https://localhost:7152/api/Image?UserId=" + UserId.ToString();
                    return Ok(new { image = path });
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int UserId, int profileStatus)
        {
            var image = await _imageRepository.GetImage(UserId, profileStatus);
            if (image == null)
            {
                return NotFound();
            }
            return File(image, "image/jpg");
        }



        [HttpPost("AddFile")]
        public async Task<IActionResult> AddFile(int Id, [FromForm] FileUpload fileUpload,string type)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    var image = await _imageRepository.SetAttachment(Id, fileUpload.files, type);
                    //string path = "https://localhost:7152/api/Image?UserId=" + filesDTO.DocId.ToString();
                    return Ok();
                }
                else
                {
                    return BadRequest("Failed");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

    public class FileUpload
    {
        public IFormFile? files { get; set; }
    }
}

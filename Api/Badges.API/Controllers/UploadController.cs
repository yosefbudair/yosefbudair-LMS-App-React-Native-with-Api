
    using Imagekit.Sdk;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.IO;
    using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
         ImagekitClient _imagekitClinet;
        
        public UploadController()
        {
        
            _imagekitClinet = new ImagekitClient("public_poE99Am+/sVutYE9q+w20TdSRHU=", "private_dKX0FqGitrMg5v1tWMBVf2F7LmI=", "https://ik.imagekit.io/bspelc5r6");
        }
        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Uploadfile()
        {
            
            try
            {
                 var files = Request.Form.Files;
                 var file = files[0];

                if (file == null || file.Length <= 0)
                {
                return BadRequest("Invalid file");
                }
            
                byte[] buffer;
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    buffer = stream.ToArray();

                }
                var name = Guid.NewGuid().ToString();
                FileCreateRequest fileC = new FileCreateRequest
                {
                    file = buffer,
                    fileName = name
                };
                var res = await _imagekitClinet.UploadAsync(fileC);
                return Ok(res.url); ;

           
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }

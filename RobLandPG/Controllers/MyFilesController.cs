using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobLandPG.Models;

namespace RobLandPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFilesController : ControllerBase
    {
        
        string path = @"E:\PublishProfiles\Robland\Images\";
        private static IWebHostEnvironment _webHostEnvironment;

        public MyFilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("UploadMyFile")]
        public async Task<string> UploadMyFile([FromForm] UploadFileModel obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {


                    //if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    //{
                    //    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    //}
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream filestream = System.IO.File.Create(path + obj.files.FileName))
                    {
                        obj.files.CopyTo(filestream);
                        filestream.Flush();
                        return path + obj.files.FileName;
                    }

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }
            else
            {
                return "Upload Failed";
            }
        }

    }
}


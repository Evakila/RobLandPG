using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobLandPG.Data;
using RobLandPG.Models;
using System.Net;

namespace RobLandPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly RoblandCMContext dbContext;
        public FilesController(RoblandCMContext dbcontext)
        {
            this.dbContext = dbcontext;
        }



        [HttpPost]
        [Route("UploadFile")]
        public async Task<ActionResult> UploadFile(IFormFile postedFile)
        //  public IActionResult UploadFile(IFormFile postedFile)
        {
            string fileName = Path.GetFileName(postedFile.FileName);
            string contentType = postedFile.ContentType;
            using (MemoryStream ms = new MemoryStream())
            {
                postedFile.CopyTo(ms);

                try
                {
                    var docc = new Tblclientdocument()
                    {

                        Clientid = 1,
                        Docname = fileName,
                        Description = fileName,
                        Contenttype = contentType,
                        Document = ms.ToArray(),
                        Username = "evans"
                    };


                    dbContext.Tblclientdocuments.Add(docc);
                    await dbContext.SaveChangesAsync();
                    return Ok("Successful");
                }
                catch (Exception ex)
                {
                    return BadRequest("Error on Upload: " + ex.Message);
                }
                
            }
        }
       
    
        #region Get Documents/Files from Db

        /// <summary>
        /// Get Documents/Files
        /// </summary>

        /// <returns></returns>
        [HttpGet]
        [Route("GetDocuments")]
        public IActionResult GetDocuments()
        {
            try
            {
                var users = dbContext.Tblclientdocuments.ToList();


                return Ok(users);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        #endregion

    }
}
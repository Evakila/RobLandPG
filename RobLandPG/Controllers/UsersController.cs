using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobLandPG.Data;
using RobLandPG.Models;

namespace RobLandPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly IConfiguration _configuration;
        //public UsersController(IConfiguration configuration)
        //{
        //    _configuration = configuration; 
        //}
        private readonly RoblandCMContext dbContext;
        public UsersController(RoblandCMContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        //[HttpGet("GetUsers")]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}
        #region Get User list 

        /// <summary>
        /// Get Users 
        /// </summary>

        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers(string SearchText)
        {
            try
            {
                string[] memi = new string[] { "value1", "value2" };
                //  return Ok("Data Retrieved successfully....");
                return Ok(memi);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        #endregion
        #region Get User list from Db

        /// <summary>
        /// Get DbUsers 
        /// </summary>

        /// <returns></returns>
        [HttpGet]
        [Route("GetDbUsers")]
        public IActionResult GetDbUsers(string SearchText)
        {
            try
            {
                var users = dbContext.Tblusers.ToList();


                return Ok(users);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        #endregion
        #region Get Specific User

        /// <summary>
        /// Get Specific User 
        /// </summary>

        /// <returns></returns>
        [HttpGet]
        [Route("GetSpecificUser")]
        public IActionResult GetSpecificUser(int ID)
        {
            try
            {
                var users = dbContext.Tblusers.Where(g=>g.Id==ID).ToList();


                return Ok(users);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        #endregion
        #region Create User

        /// <summary>
        /// Create User
        /// </summary>

        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
         public async Task<ActionResult<Tbluser>> PostTblUser(Tbluser model)
        {
            try
            {

                dbContext.Tblusers.Add(model);
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return CreatedAtAction("GetTblUser", new { id = tblUser.Id }, tblUser);
        }
        #endregion
        #region Update User

        /// <summary>
        /// Update User
        /// </summary>

        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<ActionResult<Tbluser>> UpdateTblUser(Tbluser model)
        {
            try
            {

                dbContext.Tblusers.Update(model);
                await dbContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return CreatedAtAction("GetTblUser", new { id = tblUser.Id }, tblUser);
        }
        #endregion
    }
}

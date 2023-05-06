using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Models;
using Project.Service.IService;
using System.CodeDom;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IUserService _userService;

        public ExampleController(IUserService userService)
        {
            _userService = userService;            
        }


        [HttpGet("GetAllUser_UOW")]
        public async Task<ActionResult<List<User>>> GetALlUser_UOW()
        {
            try
            {
                return _userService.GetAllUser_UOW().Result.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        [HttpGet("GetAllUser_SP")]
        public async Task<ActionResult<List<User>>> GetALlUser()
        {
            try
            {
                return _userService.GetAllUser().Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

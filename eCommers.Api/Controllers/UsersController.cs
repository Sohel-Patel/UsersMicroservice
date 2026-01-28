using eCommers.Core.DTO;
using eCommers.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("{userID}")]
        public async Task<IActionResult> GetUserByUserID(Guid userID)
        {
            if (userID == Guid.Empty)
            {
                return BadRequest("Invalid user ID");
            }
            UserDTO? userDetail = await _userService.GetUserByUserID(userID);
            if (userDetail == null)
                return NotFound(userDetail);
            
            return Ok(userDetail);
        }


    }
}
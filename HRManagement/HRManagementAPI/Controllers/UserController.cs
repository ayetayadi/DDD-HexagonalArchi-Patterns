using HRManagement.API.DTOs.UserDTO;
using HRManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using HRManagement.API.Models;

namespace HRManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Variable+Constructor
        private readonly UserServiceCRUD _userService;

        public UserController(UserServiceCRUD userService)
        {
            _userService = userService;
        }
        #endregion

        #region GetList
        [HttpGet]
        public async Task<IActionResult> GetList(Pagination model)
        {
            model.SetDefaults();
            var response = await _userService.GetListAsync(model.CurrentPage, model.PageSize);
            return Ok(response);
        }

        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetUserByIdResponse? response = await _userService.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cant be null.");
            }
            AddUserResponse response = await _userService.AddAsync(request);
            return Ok(response);
        }

        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserRequest request)
        {
            UpdateUserResponse response = await _userService.UpdateAsync(id, request);
           
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteUserResponse response = await _userService.DeleteAsync(new DeleteUserRequest { UserId = id });
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }
        #endregion
    }
}
 
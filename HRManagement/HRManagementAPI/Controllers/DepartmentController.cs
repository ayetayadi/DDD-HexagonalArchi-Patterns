using HRManagement.API.DTOs.DepartmentDTO;
using HRManagement.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        #region Variable+Constructor
        private readonly DepartmentServiceCRUD _departmentService;

        public DepartmentController(DepartmentServiceCRUD departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetDepartmentsResponse response = await _departmentService.GetAllAsync();
            return Ok(response);
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetDepartmentByIdResponse? response = await _departmentService.GetByIdAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cant be null.");
            }
            AddDepartmentResponse response = await _departmentService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.DepartmentId }, response);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentRequest request)
        {
            UpdateDepartmentResponse response = await _departmentService.UpdateAsync(id, request);

            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteDepartmentResponse response = await _departmentService.DeleteAsync(new DeleteDepartmentRequest { DepartmentId = id });
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }
        #endregion
    }
}

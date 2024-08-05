using HexagonalDesignPatterns.API.Models;
using HexagonalDesignPatterns.Application.DTOs.SmartphoneDTO;
using HexagonalDesignPatterns.Application.Ports.Driving;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalDesignPatterns.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmartphoneController : ControllerBase
    {
        #region Variables + Constructor
        private readonly ISmartphoneService _smartphoneService;

        public SmartphoneController(ISmartphoneService smartphoneService)
        {
            _smartphoneService = smartphoneService;
        }
        #endregion

        #region Get All
        [HttpGet]
        public async Task<ActionResult<GetAllSmartphonesResponse>> GetAll([FromQuery] Pagination model)
        {
            if (model == null)
            {
                return BadRequest("Pagination model is required!");
            }

            model.SetDefaults();
            GetAllSmartphonesResponse response = await _smartphoneService.GetAllAsync(model.CurrentPage, model.PageSize);
            return Ok(response);
        }

        #endregion

        #region Get By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSmartphoneByIdResponse>> GetById(int id)
        {
            var response = await _smartphoneService.GetByIdAsync(new GetSmartphoneByIdRequest { Id = id });
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        #endregion

        #region Add 
        [HttpPost]
        public async Task<ActionResult<AddSmartphoneResponse>> Add(AddSmartphoneRequest request)
        {
            AddSmartphoneResponse response = await _smartphoneService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }
        #endregion

        #region Delete 
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteSmartphoneResponse>> Delete(int id)
        {
            DeleteSmartphoneResponse response = await _smartphoneService.DeleteAsync(new DeleteSmartphoneRequest { Id = id });
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound();
        }
        #endregion
    }
}

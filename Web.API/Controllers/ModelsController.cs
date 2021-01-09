using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.DTOs;
using Services.DTOs.Models;

namespace Web.API.Controllers
{
    public class ModelsController : ApiControllerBase
    {
        private readonly ICarModelsService _carModelsService;

        public ModelsController(ICarModelsService carModelsService)
        {
            _carModelsService = carModelsService;
        }

        [Route("")]
        [HttpGet]
        public async Task<Response<PagedResult<GetModelsItemDto>>> GetModels([FromQuery] GetModelsFilterDto filterDto)
        {
            return new Response<PagedResult<GetModelsItemDto>>(await _carModelsService.GetModels(filterDto));
        }

        [Route("{id}/variants")]
        [HttpGet]
        public Task<Response<GetVariantsItemDto[]>> GetVariants(int id)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Models;

namespace Web.API.Controllers
{
    public class ModelsController : ApiControllerBase
    {
        [Route("")]
        [HttpGet]
        public Task<Response<GetModelsItemDto[]>> GetModels()
        {
            throw new NotImplementedException();
        }

        [Route("{id}/variants")]
        [HttpGet]
        public Task<Response<GetVariantsItemDto[]>> GetVariants(int id)
        {
            throw new NotImplementedException();
        }
    }
}
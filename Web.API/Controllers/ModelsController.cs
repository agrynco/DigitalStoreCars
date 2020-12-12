using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelsController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public Task<Response<GetModelsItemDto>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
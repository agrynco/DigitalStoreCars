using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Orders;

namespace Web.API.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [Route("")]
        [HttpPost]
        public Task<VoidResponse> Post(CreateOrderInputDto inputDto)
        {
            throw new NotImplementedException();
        }
    }
}
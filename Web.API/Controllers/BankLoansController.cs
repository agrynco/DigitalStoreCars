using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.BankLoans;

namespace Web.API.Controllers
{
    public class BankLoansController : ApiControllerBase
    {
        [HttpGet]
        [Route("calculate")]
        public Task<Response<CalculateBankLoanOutputDto>> CalculateBankLoan()
        {
            throw new NotImplementedException();
        }
    }
}
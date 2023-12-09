using BLL.DTOs;
using BLL.IServices;
using BLL.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class CustomersController : APIBaseController
    {
        private readonly ICustomersBL _customersService;

        public CustomersController(ICustomersBL customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerDetails([FromRoute] int customerId)
        {
            var details = await _customersService.GetCustomerDetails(customerId);
            return Ok(Helpers.CreateResponseModel(1, "Customer details", details));
        }
    }
}

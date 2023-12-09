using BLL.DTOs;
using BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
   
    public class AccountsController : APIBaseController
    {
        private readonly IAccountsBL _accountsService;

        public AccountsController(IAccountsBL accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost]
        public async Task<IActionResult> OpenAccount(OpenAccountDTO model)
        {
            return Ok(await _accountsService.OpenAccount(model));
        }
    }
}

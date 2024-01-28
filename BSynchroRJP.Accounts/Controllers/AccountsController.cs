using BSynchroRJP.Accounts.Domain.CQRS.Commands;
using BSynchroRJP.Accounts.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSynchroRJP.Accounts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> OpenAccount(OpenAccountDTO model)
        {
            try
            {
                return Ok(await _mediator.Send(new OpenAccountCommand() { CustomerId = model.CustomerId, InitialCredit = model.InitialCredit }));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

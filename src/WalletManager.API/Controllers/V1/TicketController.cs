using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Tickets;
using WalletManager.API.Contracts.Tickets;

namespace WalletManager.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public TicketController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new TicketGetAllCommand();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketCreateRequest request)
        {
            var command = new TicketCreateCommand(request.Cod,
                                                  request.Title,
                                                  request.Owner,
                                                  request.Currency,
                                                  request.PortfolioId);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }
    }
}

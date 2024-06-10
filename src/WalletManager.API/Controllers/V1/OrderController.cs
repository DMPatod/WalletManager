using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Orders;
using WalletManager.API.Contracts.Orders;

namespace WalletManager.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public OrderController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new OrderGetAllCommand();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateRequest request)
        {
            var command = new OrderCreateCommand(request.TicketId,
                                                 request.Date,
                                                 request.Type,
                                                 request.Amount,
                                                 request.Price);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }
    }
}

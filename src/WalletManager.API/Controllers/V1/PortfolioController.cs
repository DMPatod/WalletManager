using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.Portfolios;
using WalletManager.API.Contracts.Portfolios;

namespace WalletManager.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public PortfolioController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new PortfolioGetAllCommand();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PortfolioCreateRequest request)
        {
            var command = new PortfolioCreateCommand(request.Title);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Errors);
        }
    }
}

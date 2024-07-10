using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WalletManager.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(IMessageHandler messageHandler, SignInManager<IdentityUser> signInManager)
        {
            _messageHandler = messageHandler;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register()
        {
            return Created("", null);
        }
    }
}

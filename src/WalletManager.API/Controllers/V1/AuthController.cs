using Auth.Application.Auth;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Mvc;
using WalletManager.API.Contracts.Account;

namespace WalletManager.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMessageHandler _messageHandler;

        public AuthController(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            string user = null;
            try
            {
                user = HttpContext.User.GetSubjectId();
            }
            catch { }
            return Ok(new { auth = HttpContext.User.IsAuthenticated(), user, identity = HttpContext.User.Identity });
        }

        [HttpPost("signIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var command = new SignInCommand(request.Username, request.Password);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception("Error signing in user");
            }
            return Ok(result.Value);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Username, request.Email, request.Password);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception("Error registering user");
            }
            return CreatedAtAction(nameof(Get),
                                   new { id = result.Value.Id },
                                   result.Value);
        }

        [HttpPost("passwordForgot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PasswordForgot(PasswordForgotRequest request)
        {
            var command = new GeneratePasswordResetTokenCommand(request.Email);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception("Error resetting password");
            }

            return Ok(result.Value);
        }

        [HttpPost("passwordReset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PasswordReset(PasswordResetRequest request)
        {
            var command = new ResetPasswordCommand(request.Email, request.Token, request.Password);
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception("Error resetting password");
            }

            return Ok("Password reset successfully");
        }

        [HttpPost("signOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignOut()
        {
            var command = new SignOutCommand();
            var result = await _messageHandler.SendAsync(command, CancellationToken.None);
            if (result.IsFailed)
            {
                throw new Exception("Error signing out user");
            }
            return Ok("User signed out successfully");
        }
    }
}

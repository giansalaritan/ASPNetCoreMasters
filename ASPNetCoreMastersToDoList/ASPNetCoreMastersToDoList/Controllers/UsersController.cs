using ASPNetCoreMastersToDoList.BindingModels;
using ASPNetCoreMastersToDoList.ConfigModels;
using DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTConfigModel _jwt;
        private readonly UserManager<User> _userManager;

        public UsersController(IOptions<JWTConfigModel> options, UserManager<User> userManager)
        {
            _jwt = options.Value;
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                return Ok(new { code = code, email = model.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ConfirmEmail(ConfirmBindingModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Code));

            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            }
            else if ((await _userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                return Ok("Your email is confirmed.");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            IActionResult actionResult;
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                actionResult = NotFound(new { errors = new[] { $"User with email '{model.Email}' was not found." } });
            }
            else if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                if (!user.EmailConfirmed)
                {
                    actionResult = BadRequest(new { errors = new[] { "Email is not yet confirmed. Please go to your email account and verify." } });
                }
                else
                {
                    var token = GenerateTokenAsync(user);
                    actionResult = Ok(token);
                }
            }
            else
            {
                actionResult = BadRequest(new { errors = new[] { "User password is incorrect." } });
            }
            return actionResult;
        }

        private string GenerateTokenAsync(User user)
        {
            IList<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            return new JwtSecurityTokenHandler().WriteToken(
                new JwtSecurityToken(
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMonths(1),
                    signingCredentials: new SigningCredentials(_jwt.SecurityKey, SecurityAlgorithms.HmacSha256)
                    )
                );
        }
    }
}

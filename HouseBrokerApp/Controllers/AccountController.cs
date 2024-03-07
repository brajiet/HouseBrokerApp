using HouseBrokerApp.Data.Entities;
using HouseBrokerApp.Domain.Models;
using HouseBrokerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HouseBrokerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenService _tokenService;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtTokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (model.IsBroker)
                {
                    await _userManager.AddToRoleAsync(user, "Broker");
                    user.IsBroker = true;
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "HouseSeeker");
                    user.IsBroker = false;
                }

                await _userManager.UpdateAsync(user);

                return Ok("Registration successful");
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(string.Join(", ", errors));
        }
        [HttpPost]
        [Route("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string Email)
        {
            
            var user = await _userManager.FindByNameAsync(Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Ok("Email confirmed successfully.");
            }

            return BadRequest("Email confirmation failed.");
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        if (user.IsBroker)
                        {
                            var token = _tokenService.GenerateJwtToken(model);
                            return Ok(token);
                        }
                        else
                        {
                            // User is a house seeker
                            var token = _tokenService.GenerateJwtToken(model);
                            return Ok(token);
                        }
                    }
                    return NotFound("User not found");
                }
                return BadRequest("Invalid login attempt");
            }
            return BadRequest(ModelState);
        }

    }
}


using assigment.Models;
using assigment.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace assigment.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ApiTokenController : Controller
    {

        private readonly SignInManager<ApplicationUser> signInManager;
        private IHostingEnvironment _HostingEnviroment;
        private UserManager<ApplicationUser> UserManager { get; }



        public ApiTokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
             IHostingEnvironment hostingEnviroment)
        {
            this.UserManager = userManager;
            this.signInManager = signInManager;
            _HostingEnviroment = hostingEnviroment;
        }





        [HttpPost]
        [Route("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] JWTTokenViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByNameAsync(model.UserName);
                var signInResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (signInResult.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MVSJwtTokens.key));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub,model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName,model.UserName)
                    };
                    var token = new JwtSecurityToken(
                        MVSJwtTokens.Issuer,
                        MVSJwtTokens.Audience,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: creds
                        );
                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };
                    return Created("", results);
                }
                else
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}

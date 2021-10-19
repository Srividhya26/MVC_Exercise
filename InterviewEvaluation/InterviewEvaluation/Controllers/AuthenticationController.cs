﻿using InterviewEvaluation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InterviewEvaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> user, RoleManager<IdentityRole> role, IConfiguration configuration)
        {
            this._user = user;
            this._role = role;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var userExist = await _user.FindByNameAsync(register.UserName);
            if(userExist != null)
            
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new Response { Status = "Error" , Message = "User already exist"});
            
           
             ApplicationUser user = new ApplicationUser()
             {
                 Email = register.Email,
                 SecurityStamp = Guid.NewGuid().ToString(),
                 UserName = register.UserName
             };

             var result = await _user.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User creation failed" });
            }
            else
            {
                return Ok(new Response { Status = "Success", Message = "User created Successfully" });
            }
            
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await _user.FindByNameAsync(login.UserName);

            if(user!=null && await _user.CheckPasswordAsync(user,login.Password))
            {
                var userRoles = await _user.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims : authClaims,
                    signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256));
                     
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register register)
        {
            var userExist = await _user.FindByNameAsync(register.UserName);
            if (userExist != null)

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User already exist" });


            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName
            };

            var result = await _user.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User creation failed" });
            }
            if (!await _role.RoleExistsAsync(userRole.HR))
                await _role.CreateAsync(new IdentityRole(userRole.HR));
            if (!await _role.RoleExistsAsync(userRole.Interviewer))
                await _role.CreateAsync(new IdentityRole(userRole.Interviewer));
            if(await _role.RoleExistsAsync(userRole.HR))
            {
                await _user.AddToRoleAsync(user, userRole.HR);
            }
            return Ok(new Response { Status = "Success", Message = "User created Successfully" });          

        }


    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreLIS.API.Data;
using CoreLIS.API.DTOs;
using CoreLIS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoreLIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {

            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();
            if (await _repo.UserExists(userToRegisterDTO.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userToRegisterDTO.Username
            };

            var createdUser = await _repo.Register(userToCreate, userToRegisterDTO.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDTO userToLogin)
        {
            userToLogin.Username = userToLogin.Username.ToLower();

            var userFromRepo = await _repo.Login(userToLogin.Username, userToLogin.Password);
            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(
                new {
                    token = tokenHandler.WriteToken(token)
                }
            );
        }
    }
}
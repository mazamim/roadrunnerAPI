using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using mywep.API.Data;
using roadrunnerapi.DTO;
using roadrunnerapi.Models;

namespace roadrunnerapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {

        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
             _mapper = mapper;
            _repo = repo;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserforRegisterDTO userforRegisterDTO)
        {
            userforRegisterDTO.Username = userforRegisterDTO.Username.ToLower();
            if (await _repo.UserExist(userforRegisterDTO.Username)) return BadRequest("UserName already Exists");

            var userToCreate =_mapper.Map<User>(userforRegisterDTO);

            var createdUser = await _repo.Register(userToCreate, userforRegisterDTO.Password);
            
            var userToReturn = _mapper.Map<UserForDetailedDTO>(createdUser);

            return CreatedAtRoute("GetUser", new { controller = "Users", 
                id = createdUser.Id }, userToReturn);
        }

                [HttpPost("Login")]
        public async Task<IActionResult> Login(UserforLogInDTO UserforLogInDTO)
        {
            var userFromRepo = await _repo.Login(UserforLogInDTO.Username.ToLower(), UserforLogInDTO.Password);
            if (userFromRepo == null)
                return Unauthorized();

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
            var user= _mapper.Map<UserForDetailedDTO>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user

            });
        }
    }
}
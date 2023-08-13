using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Register_A_Person_In_A_Database_Backend_.Data.Interfaces;
using Register_A_Person_In_A_Database_Backend_.Dto;
using Register_A_Person_In_A_Database_Backend_.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Register_A_Person_In_A_Database_Backend_.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous] // Allow anonymous access to authentication endpoints
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto model)
        {
            // Register a new user with provided registration data

            // Validate the incoming model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new User instance with registration data
            var user = new User
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                Email = model.Email
            };

            // Create the user and associate with a role
            var createdUser = await _userRepository.CreateUserAsync(user, model.Password);
            if (createdUser == null)
            {
                return BadRequest("User creation failed.");
            }

            // Ensure the user is assigned the specified role
            var roleAssignmentResult = await _userRepository.EnsureRoleExistsAndAssignToUserAsync(createdUser, model.Role);
            if (!roleAssignmentResult)
            {
                return BadRequest("Role assignment failed.");
            }

            // Return success if user registration is successful
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            // Authenticate user and generate JWT token for valid login

            // Validate the incoming model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find user by username
            var user = await _userRepository.FindUserByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            // Check if provided password is valid
            var isPasswordValid = await _userRepository.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            // Generate JWT token for authenticated user
            var token = GenerateJwtToken(user);
            Response.Headers.Add("Authorization", "Bearer " + token);

            // Return token in response
            return Ok(new { Token = token });
        }

        // Generate JWT token for the authenticated user
        private string GenerateJwtToken(User user)
        {
            // Configure JWT settings from app configuration
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");

            // Define token properties and claims
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Generate and serialize the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize] // Require authorized access to log out
        public async Task<IActionResult> Logout()
        {
            // Log out the current authenticated user

            // Perform user logout action
            await _userRepository.LogoutAsync();
            return Ok();
        }
    }
}

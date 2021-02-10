using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Security.Claims;
using System;
using vehiclesStoreAPI.Repositories;
using System.Collections.Generic;
using vehiclesStoreAPI.Models;
using vehiclesStoreAPI.DTO;
using AutoMapper;

namespace vehiclesStoreAPI.Controllers
{
  [ApiController]
  [Authorize]
  [Route("/api/v1/account")]
  public class AccountController : ControllerBase
  {
    private readonly ILogger<AccountController> _logger;
    private readonly IUsersRepository _repository;
    private readonly IMapper _mapper;
    private IJWTAuthRepository _jwtAuthManager;

    public AccountController(IUsersRepository repository, IMapper mapper, IJWTAuthRepository jwtAuthManager, ILogger<AccountController> logger)
    {
      _repository = repository;
      _mapper = mapper;
      _jwtAuthManager = jwtAuthManager;
      _logger = logger;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public ActionResult<UserDTO> Signup(User user)
    {
      if (!ModelState.IsValid) return BadRequest();
      _repository.Signup(user);
      _repository.SaveChanges();
      return Ok(_mapper.Map<UserDTO>(user));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult Login([FromBody] LoginRequest req)
    {
      if (!ModelState.IsValid) return BadRequest();

      var username = req.Username;
      var password = req.Password;

      if (!_repository.AreValidUserCredentials(username, password))
      {
        return Unauthorized();
      }

      var role = _repository.GetUserRole(username);

      var claims = new[]{
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role[0]),
      };

      var jwt = _jwtAuthManager.GenerateTokens(username, claims, DateTime.Now);
      _logger.LogInformation($"User [{username}] is logged in!");

      return Ok(new LoginResponse
      {
        Username = username,
        Role = role,
        AccessToken = jwt.AccessToken,
        RefreshToken = jwt.RefreshToken.TokenString,
      });
    }

    [HttpPost("logout")]
    [Authorize]
    public ActionResult Logout()
    {
      var username = User.Identity.Name;
      // Not ideal & bad UX
      // can be more specific to IP, user agent, device...
      _jwtAuthManager.RemoveRefreshTokensByUsername(username);
      _logger.LogInformation($"[{username} has logged out!]");
      return Ok();
    }

    public class SignupRequest
    {
      [Required]
      [JsonPropertyName("username")]
      public string Username { get; set; }
      [Required]
      [JsonPropertyName("password")]
      public string Password { get; set; }
    }

    public class LoginRequest
    {
      [Required]
      [JsonPropertyName("username")]
      public string Username { get; set; }
      [Required]
      [JsonPropertyName("password")]
      public string Password { get; set; }
    }

    public class LoginResponse
    {
      [JsonPropertyName("username")]
      public string Username { get; set; }
      [JsonPropertyName("role")]
      public List<string> Role { get; set; }
      [JsonPropertyName("accessToken")]
      public string AccessToken { get; set; }
      [JsonPropertyName("refreshToken")]
      public string RefreshToken { get; set; }
    }
  }
}
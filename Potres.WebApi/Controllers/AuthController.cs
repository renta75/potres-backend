using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Potres.Contracting.Security;
using Potres.WebApi.Models;
using Potres.WebApi.Util.Security;
using Potres.WebApi.ViewModels;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Potres.WebApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IUserManagementService managementService;
    private readonly ITokenUtil tokenUtil;
    private readonly TokenConfig tokenConfig;

    public AuthController(IUserManagementService managementService, ITokenUtil tokenUtil, IOptionsSnapshot<TokenConfig> options)
    {
      this.managementService = managementService;
      this.tokenUtil = tokenUtil;
      this.tokenConfig = options.Value;
    }
    // GET api/values
    [HttpPost, Route("create_token")]
    [AllowAnonymous]
    public async Task<ActionResult<Tokens>> CreateToken([FromBody] LoginModel model)
    {
      if (model == null || !ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      bool isValid = await managementService.IsValidUser(model.Username, model.Password);
      if (isValid)
      {
        Tokens tokens = await CreateTokens(model.Username);
        await managementService.AddRefreshToken(model.Username, tokens.RefreshToken, tokenConfig.RefreshTokenDays);
        return tokens;
      }
      else
      {
        return Unauthorized();
      }
    }

    private async Task<Tokens> CreateTokens(string username)
    {
      UserDto user = await managementService.GetUserData(username);
      List<RoleDto> roles = await managementService.GetUserRoles(username);
      var claims = user.CreateClaims(roles);
      var token = tokenUtil.CreateToken(claims);
      var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

      string refreshToken = tokenUtil.GenerateRefreshToken();

      return new Tokens
      {
        Token = tokenString,
        RefreshToken = refreshToken
      };
    }

    [HttpPost, Route("refresh_token")]
    [AllowAnonymous]
    public async Task<ActionResult<Tokens>> RefrehToken([FromBody] Tokens model)
    {
      if (model == null || !ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      //tko je vlasnik tokena?
      var principal = tokenUtil.GetPrincipalFromExpiredToken(model.Token);
      string username = principal.Identity.Name;

      //ima li taj korisnik navedeni refresh token
      bool isRefreshTokenValid = await managementService.IsValidRefreshToken(username, model.RefreshToken);

      //ako da, generiraj novi refresh token, snimi ga, stari obriši
      if (isRefreshTokenValid)
      {
        Tokens tokens = await CreateTokens(username);
        await managementService.ReplaceRefreshToken(username, model.RefreshToken, tokens.RefreshToken, tokenConfig.RefreshTokenDays);
        return tokens;
      }
      else
      {
        return Unauthorized("Invalid refresh token");
      }
    }
  }
}

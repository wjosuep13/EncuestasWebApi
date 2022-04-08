using EncuestasAPI.Models;
using EncuestasAPI.Repository.Interface;
using JWTWebAuthentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IJWTManagerRepository _jWTManager;

	public UsersController(IJWTManagerRepository jWTManager)
	{
		this._jWTManager = jWTManager;
	}

	

	[AllowAnonymous]
	[HttpPost]
	[Route("authenticate")]
	public IActionResult Authenticate(Users usersdata)
	{
		var token = _jWTManager.Authenticate(usersdata);

		if (token == null)
		{
			return Unauthorized();
		}

		return Ok(token);
	}
}
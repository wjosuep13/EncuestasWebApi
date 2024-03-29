﻿using EncuestasAPI.Models;
using JWTWebAuthentication.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

public class JWTManagerRepository : IJWTManagerRepository
{
	Dictionary<string, string> UsersRecords = new Dictionary<string, string>
	{
		{ "wjosuep13","testpass"},
	};

	private readonly IConfiguration iconfiguration;
	public JWTManagerRepository(IConfiguration iconfiguration)
	{
		this.iconfiguration = iconfiguration;
	}
	public Tokens Authenticate(Users users)
	{
		if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
		{
			return null;
		}

		// Else we generate JSON Web Token
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
		  {
			 new Claim(ClaimTypes.Name, users.Name)
		  }),
			Expires = DateTime.UtcNow.AddMinutes(10),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return new Tokens { Token = tokenHandler.WriteToken(token) };

	}
}
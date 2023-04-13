using Microsoft.IdentityModel.Tokens;
using NetECommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace NetECommerce.Common
{
    public static class JwtProvider
    {
        public static string GenerateJwtToken(AppUser user)
        {
           

            //Claim
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               

            };

            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b51487ad3be4760cada8cfb4523451c2459f8c398d98ee3657ca4729797195d7"));

            var credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var expries = DateTime.Now.AddDays(Convert.ToDouble(365));

           var token = new JwtSecurityToken(issuer: "https://localhost:44345", audience: "https://localhost:44345", claims: claims, expires: expries, signingCredentials: credentials);


            var result=new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }
    }
}

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using TXTKikanSystem.Models;

namespace TXTKikanSystem.FunctionLocation
{
    public class FunctionReadToken
    {
        public TokenViewModel ReadToken(string token)
        {
            var result = new TokenViewModel();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokens = jsonToken as JwtSecurityToken;
            // check RoleUser Limit by eventCode
            string roleUser = tokens.Claims.FirstOrDefault(claim => claim.Type == "roleID").Value;
            string experiedToken = tokens.Claims.FirstOrDefault(claim => claim.Type == "experiedDate").Value;
            string nameEmployer = tokens.Claims.FirstOrDefault(claim => claim.Type == "employerName").Value;
            string nameRole = tokens.Claims.FirstOrDefault(claim => claim.Type == "nameRole").Value;
            string userID = tokens.Claims.FirstOrDefault(claim => claim.Type == "userID").Value;
            
            result.Role = roleUser;
            result.Employer = nameEmployer;
            result.ExpirationDate = DateTime.Parse(experiedToken);
            result.DescriptionRole = nameRole;
            result.Token = token;
            result.UserID = userID;

            return result;
        }
    }
}

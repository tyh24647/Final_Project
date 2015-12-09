using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Final_Project.Services {
    public class SecurityProvider : ISecurityProvider {
        private RSACryptoServiceProvider keys;

        public SecurityProvider() {
            keys = new RSACryptoServiceProvider(2048);
        }

        public string GetToken(List<Claim> claims) {
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new RsaSecurityKey(keys.ExportParameters(true)), SecurityAlgorithms.RsaSha256Signature, SecurityAlgorithms.Sha256Digest);
            var token = new JwtSecurityToken("www.webprogrammingassignment2015.com", "www.bethel.edu", claims, DateTime.UtcNow, DateTime.UtcNow.AddDays(7), credentials);
            return handler.WriteToken(token);
        }

        public bool Validate(string token) {
            var validationParameters = new TokenValidationParameters() {
                ValidIssuer = "www.webprogrammingassignment2015.com",
                ValidAudience = "www.bethel.edu",
                IssuerSigningKey = new RsaSecurityKey(keys.ExportParameters(true))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            try {
                tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            } catch (Exception) {
                return false;
            }

            return true;
        }
    }
}
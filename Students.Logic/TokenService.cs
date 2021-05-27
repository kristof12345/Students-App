using System;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace InvestmentApp.Logic.Services
{
    public static class TokenService
    {
        private const string secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(IdentityUser user)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(secret)
                .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10000).ToUnixTimeSeconds())
                .AddClaim("id", user.Id)
                .AddClaim("username", user.UserName)
                .Encode();
            return token;
        }

        public static IdentityUser DecodeToken(string token)
        {
            string json = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(secret).MustVerifySignature().Decode(token);
            return JsonConvert.DeserializeObject<IdentityUser>(json);
        }
    }
}

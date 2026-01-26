using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUserEmail(this ClaimsPrincipal claims)
        {
            return claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
    }
}
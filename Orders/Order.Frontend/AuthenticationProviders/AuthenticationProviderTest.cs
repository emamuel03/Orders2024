﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Order.Frontend.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(1500);
            var anonymous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Emmanuel"),
                new Claim("LastName", "Gomez"),
                new Claim(ClaimTypes.Name, "egomez@tucumail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(admin)));
        }
    }
}

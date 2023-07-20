using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DemoProject.Tools
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private IJSRuntime _js;
        public AuthProvider(IJSRuntime js)
        {
            _js = js;
        }

        public ClaimsPrincipal CurrentUser { get; set; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            string token = await _js.InvokeAsync<string>("localStorage.getItem", "token");
            List<Claim> claims = new List<Claim>();

            //Au cas ou mon user n'est pas connecté => création d'un anonyme
            if (string.IsNullOrEmpty(token))
            {
                ClaimsIdentity anonymousUser = new ClaimsIdentity();
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymousUser)));
            }

            JwtSecurityToken jwt = new JwtSecurityToken(token);

            foreach (Claim item in jwt.Claims)
            {
                claims.Add(item);
            }

            ClaimsIdentity currentUser = new ClaimsIdentity(claims, "MyAuthSystem");
            //CurrentUser = new ClaimsPrincipal(currentUser);
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}

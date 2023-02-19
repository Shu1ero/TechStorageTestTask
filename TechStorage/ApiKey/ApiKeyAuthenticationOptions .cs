using Microsoft.AspNetCore.Authentication;

namespace TechStorageAPI.ApiKey
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; }
    }
}

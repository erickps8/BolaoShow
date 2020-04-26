using Microsoft.AspNetCore.Identity;

namespace BolaoShow.Api.Data
{
    public class CustomIdentity : IdentityUser
    {
        public string Nome { get; set; }
    }
}

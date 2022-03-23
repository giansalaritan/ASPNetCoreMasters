using Microsoft.IdentityModel.Tokens;

namespace ASPNetCoreMastersToDoList.ConfigModels
{
    public class JWTConfigModel
    {
        public SecurityKey SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

namespace ASPNetCoreMastersToDoList.ConfigModels
{
    public class JWTConfigModel
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

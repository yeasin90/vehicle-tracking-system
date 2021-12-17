namespace VTS.Backend.Infrastructure.AuthServer.Settings
{
    public class AuthorizationServerSettings
    {
        public string Host { get; set; }
        public string Audience { get; set; }
        public string FrontEndClientId { get; set; }
        public string FrotEndClientSecret { get; set; }
    }
}

namespace VTS.Backend.Infrastructure.AuthServer
{
    public static class OidcConstants
    {
        public static class Oidc
        {
            public const string Authorize = "connect/authorize";
            public const string Consent = "connect/consent";
            public const string SwitchUser = "connect/switch";
            public const string DiscoveryConfiguration = ".well-known/openid-configuration";
            public const string DiscoveryWebKeys = ".well-known/jwks";
            public const string Token = "connect/token";
            public const string Revocation = "connect/revocation";
            public const string UserInfo = "connect/userinfo";
            public const string AccessTokenValidation = "connect/accessTokenValidation";
            public const string Introspection = "connect/introspect";
            public const string IdentityTokenValidation = "connect/identityTokenValidation";
            public const string EndSession = "connect/endsession";
            public const string EndSessionCallback = "connect/endsessioncallback";
            public const string CheckSession = "connect/checksession";
        }
    }
}

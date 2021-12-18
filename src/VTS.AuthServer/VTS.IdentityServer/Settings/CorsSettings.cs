using System.Collections.Generic;

namespace VTS.IdentityServer.Settings
{
    public class CorsSettings
    {
        public string Name { get; set; }
        public List<string> AllowedHosts { get; set; }
    }
}

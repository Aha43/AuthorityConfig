using System.Collections.Generic;

namespace AuthorityConfig.Infrastructure.DIPS.Front.Manager
{
    public class IdProviderOptions
    {
        private string _JwtAssertionAud = string.Empty;

        public string Type { get; set; }
        public string Scheme { get; set; }
        public string IdentityClaim { get; set; }
        public string HpnrClaim { get; set; }
        public string DisplayName { get; set; }
        public string ClientId { get; set; }
        public string CallbackPath { get; set; }
        public string MetadataAddress { get; set; }
        public string Wtrealm { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public string Authority { get; set; }
        public string JwtAssertionAud
        {
            get
            {
                return string.IsNullOrEmpty(_JwtAssertionAud) ? Authority : _JwtAssertionAud;
            }
            set
            {
                _JwtAssertionAud = value;
            }
        }
        public IEnumerable<string> MatchResources { get; set; }
        public string[] Scopes { get; set; }
        public string CertificateThumbprint { get; set; }

        public string ClientSecret { get; set; } // If not sat the below is used for jwt bearer token construction
        public bool SkipX5C { get; set; }
        public bool SkipKid { get; set; }
        public string RsaXml { get; set; }
        public string OrgNo { get; set; }
        public int TokenLifeTimeInSeconds { get; set; }
        public string SecurityAlgorithm { get; set; }

        public bool PKCE { get; set; } = false;
    }
}

using AuthorityConfig.Domain.Exceptions;
using AuthorityConfig.Domain.Oidc;
using AuthorityConfig.Utility;
using System;
using System.Collections.Generic;

namespace AuthorityConfig.Domain.Param
{
    public class SetClientParam : BaseParam
    {
        public bool DryRun { get; set; } //
        public string Authority { get; set; } //
        public bool CreateIfDoesNotExists { get; set; } = false; //
        public string ClientId { get; set; } //
        public string ClientName { get; set; } //
        public string Description { get; set; } //
        public string ClientUri { get; set; } //
        public string LogoUri { get; set; } //
        public bool? Enabled { get; set; } //
        public bool? RequireClientSecret { get; set; } //
        public bool? RequireConsent { get; set; } //
        public bool? AllowRememberConsent { get; set; } //
        public string GrantTypesToAdd { get; set; } //
        public string GrantTypesToRemove { get; set; } //
        public string ClientSecret { get; set; } //
        public string ScopesToAdd { get; set; } //
        public string ScopesToRemove { get; set; }

        public override void Valid()
        {
            var l = new List<string>();
            if (string.IsNullOrEmpty(Authority)) l.Add(nameof(Authority));
            if (string.IsNullOrEmpty(ClientId)) l.Add(nameof(ClientId));
            if (l.Count > 0)
            {
                throw new InvalidParamException("Missing: " + string.Join(',', l));
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(ClientUri)) ClientUri = ClientUri.ValidAbsoluteUri();
                if (!string.IsNullOrWhiteSpace(LogoUri)) LogoUri = LogoUri.ValidAbsoluteUri();

                if (!string.IsNullOrEmpty(GrantTypesToAdd)) GrantTypesToAdd.ValidGrants(true);
                if (!string.IsNullOrEmpty(GrantTypesToRemove)) GrantTypesToRemove.ValidGrants(true);
            }
            catch (Exception ex)
            {
                throw new InvalidParamException(ex);
            }
        }

    }

}

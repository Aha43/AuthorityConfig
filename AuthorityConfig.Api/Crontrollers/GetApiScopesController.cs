using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthorityConfig.Api.Crontrollers
{
    public class GetApiScopesController : PostControllerTemplateWithResultParam<IEnumerable<ApiScope>, AuthorityParam>
    {
        public GetApiScopesController(IAuthorityManager authorityManager) : base(authorityManager.GetApiScopesAsync) { }
    }
}

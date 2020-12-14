using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class AddApiScopeController : PostControllerTemplateWithParam<AddApiParam>
    {
        public readonly IAuthorityManager _authorityManager;

        public AddApiScopeController(IAuthorityManager authorityManager) : base(authorityManager.AddApiScopeAsync) { }
    }
}

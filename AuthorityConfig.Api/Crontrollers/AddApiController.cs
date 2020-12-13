using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class AddApiController : PostControllerTemplateWithParam<AddApiParam>
    {
        public readonly IAuthorityManager _authorityManager;

        public AddApiController(IAuthorityManager authorityManager) : base(authorityManager.AddApiAsync) { }
    }
}

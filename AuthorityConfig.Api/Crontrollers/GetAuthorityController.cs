using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class GetAuthorityController : PostControllerTemplateWithResultParam<Authority, GetAuthorityParam>
    {
        public GetAuthorityController(IAuthorityManager authorityManager) : base(authorityManager.GetAuthorityAsync) { }
    }
}

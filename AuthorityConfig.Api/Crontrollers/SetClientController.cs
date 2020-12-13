using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class SetClientController : PostControllerTemplateWithParam<SetClientParam>
    {
        public SetClientController(IAuthorityManager authorityManager) : base(authorityManager.SetClientAsync) { }
    }
}

using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetClientController : PostControllerTemplateWithParam<SetClientParam>
    {
        public SetClientController(IAuthorityManager authorityManager) : base(authorityManager.SetClientAsync) { }
    }
}

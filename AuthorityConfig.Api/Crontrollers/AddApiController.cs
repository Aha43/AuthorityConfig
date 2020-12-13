using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddApiController : PostControllerTemplateWithParam<AddApiParam>
    {
        public readonly IAuthorityManager _authorityManager;

        public AddApiController(IAuthorityManager authorityManager) : base(authorityManager.AddApiAsync) { }
    }
}

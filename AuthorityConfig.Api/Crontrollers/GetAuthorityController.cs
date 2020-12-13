using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAuthorityController : PostControllerTemplateWithResultParam<Authority, GetAuthorityParam>
    {
        public GetAuthorityController(IAuthorityManager authorityManager) : base(authorityManager.GetAuthorityAsync) { }
    }
}

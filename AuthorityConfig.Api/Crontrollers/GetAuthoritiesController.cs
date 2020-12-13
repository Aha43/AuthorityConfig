using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAuthoritiesController : PostControllerTemplateWithResult<Authorities> 
    { 
        public GetAuthoritiesController(IAuthorityManager authorityManager) : base(authorityManager.GetAuthoritiesAsync) { }
    }
}

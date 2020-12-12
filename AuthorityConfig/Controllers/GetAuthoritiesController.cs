using AuthorityConfig.Controllers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAuthoritiesController : ControllerTemplateWithResult<Authorities> 
    { 
        public GetAuthoritiesController(IAuthorityManager authorityManager) : base(authorityManager.GetAuthoritiesAsync) { }
    }
}

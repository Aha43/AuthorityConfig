using AuthorityConfig.Controllers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddApiController : ControllerTemplate<AddApiParam>
    {
        public readonly IAuthorityManager _authorityManager;

        public AddApiController(IAuthorityManager authorityManager) : base(authorityManager.AddApiAsync) { }
    }
}

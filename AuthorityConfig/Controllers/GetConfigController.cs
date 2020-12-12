using AuthorityConfig.Controllers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetConfigController : ControllerTemplateWithResultParam<IdserverConfig, GetConfigParam>
    {
       public GetConfigController(IAuthorityManager authorityManager) : base(authorityManager.GetConfigurationAsync) { }
    }
}

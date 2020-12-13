using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetConfigController : PostControllerTemplateWithResultParam<object, GetConfigParam>
    {
       public GetConfigController(IAuthorityManager authorityManager) : base(authorityManager.GetConfigurationAsync) { }
    }
}

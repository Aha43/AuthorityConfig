using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class GetConfigController : PostControllerTemplateWithResultParam<object, AuthorityParam>
    {
       public GetConfigController(IAuthorityManager manager) : base(manager.GetConfigurationAsync) { }
    }
}

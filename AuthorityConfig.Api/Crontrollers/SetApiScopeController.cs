using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class SetApiScopeController : PostControllerTemplateWithParam<SetApiParam>
    { 
        public SetApiScopeController(IApiScopeManager manager) : base(manager.SetApiScopeAsync) { }
    }
}

using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Domain.Response;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class SetApiScopeController : PostControllerTemplateWithResultParam<SetApiScopeResponse, SetApiParam>
    { 
        public SetApiScopeController(IApiScopeManager manager) : base(manager.SetApiScopeAsync) { }
    }
}

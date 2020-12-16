using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class AddApiScopeController : PostControllerTemplateWithParam<AddApiParam>
    { 
        public AddApiScopeController(IApiScopeManager manager) : base(manager.AddApiScopeAsync) { }
    }
}

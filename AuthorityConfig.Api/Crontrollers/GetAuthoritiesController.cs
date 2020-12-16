using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Model;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class GetAuthoritiesController : PostControllerTemplateWithResult<Authorities> 
    { 
        public GetAuthoritiesController(IAuthorityManager manager) : base(manager.GetAuthoritiesAsync) { }
    }
}

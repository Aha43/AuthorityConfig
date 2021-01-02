using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Domain.Response;
using AuthorityConfig.Specification.Business;

namespace AuthorityConfig.Api.Crontrollers
{
    public class SetClientController : PostControllerTemplateWithResultParam<SetClientResponse, SetClientParam>
    {
        public SetClientController(IClientManager manager) : base(manager.SetClientAsync) { }
    }
}
 
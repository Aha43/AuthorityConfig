using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthorityConfig.Api.Crontrollers
{
    public class GetClientsController : PostControllerTemplateWithResultParam<IEnumerable<Client>, AuthorityParam>
    {
        public GetClientsController(IClientManager manager) : base(manager.GetClientsAsync) { }
    }
}

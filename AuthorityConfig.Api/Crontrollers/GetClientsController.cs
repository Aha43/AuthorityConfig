using AuthorityConfig.Api.Crontrollers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetClientsController : PostControllerTemplateWithResultParam<IEnumerable<Client>, GetClientsParam>
    {
        public GetClientsController(IAuthorityManager authorityManager) : base(authorityManager.GetClientsAsync) { }
    }
}

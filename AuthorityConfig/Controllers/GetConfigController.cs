using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Domain.Response;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetConfigController : Controller
    {
        public readonly IAuthorityManager _authorityManager;

        public GetConfigController(
            IAuthorityManager authorityManager)
        {
            _authorityManager = authorityManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GetConfigParam param)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var result = await _authorityManager.GetConfigurationAsync(param, cts.Token);
                return new OkObjectResult(new AuthorityConfigResponseWithData<IdserverConfig>(result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponseWithData<IdserverConfig>(ex));
            }
        }

    }

}

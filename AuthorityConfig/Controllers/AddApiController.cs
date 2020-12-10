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
    public class AddApiController : Controller
    {
        public readonly IAuthorityManager _authorityManager;

        public AddApiController(
            IAuthorityManager authorityManager)
        {
            _authorityManager = authorityManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddApiParam param)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                await _authorityManager.AddApiAsync(param, cts.Token);
                return new OkObjectResult(new AuthorityConfigResponse());
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponse(ex));
            }
        }
    }
}

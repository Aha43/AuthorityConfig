using AuthorityConfig.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Controllers.Templates
{
    public class ControllerTemplateWithResultParam<T, P> : Controller
    {
        private readonly Func<P, CancellationToken, Task<T>> _func;

        public ControllerTemplateWithResultParam(Func<P, CancellationToken, Task<T>> func)
        {
            _func = func;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] P param)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var result = await _func(param, cts.Token);
                return new OkObjectResult(new AuthorityConfigResponseWithData<T>(result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponseWithData<T>(ex));
            }
        }

    }

}

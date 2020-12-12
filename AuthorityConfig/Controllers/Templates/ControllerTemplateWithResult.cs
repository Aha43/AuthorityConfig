using AuthorityConfig.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Controllers.Templates
{
    public class ControllerTemplateWithResult<T> : Controller
    {
        private readonly Func<CancellationToken, Task<T>> _func;

        public ControllerTemplateWithResult(Func<CancellationToken, Task<T>> func)
        {
            _func = func;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                using var cts = new CancellationTokenSource();
                var result = await _func(cts.Token);
                return new OkObjectResult(new AuthorityConfigResponseWithData<T>(result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponseWithData<T>(ex));
            }
        }

    }

}

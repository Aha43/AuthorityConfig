using AuthorityConfig.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Api.Crontrollers.Templates
{
    public class PostControllerTemplateWithResult<R>
    {
        private readonly Func<CancellationToken, Task<R>> _func;

        public PostControllerTemplateWithResult(Func<CancellationToken, Task<R>> func)
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
                return new OkObjectResult(new AuthorityConfigResponseWithData<R>(result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponseWithData<R>(ex));
            }
        }

    }

}

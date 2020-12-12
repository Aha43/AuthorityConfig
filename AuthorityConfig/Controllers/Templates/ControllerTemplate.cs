﻿using AuthorityConfig.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Controllers.Templates
{
    public class ControllerTemplate<P> : Controller
    {
        private readonly Func<P, CancellationToken, Task> _func;

        public ControllerTemplate(Func<P, CancellationToken, Task> func)
        {
            _func = func;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] P param)
        {
            try
            {
                using var cts = new CancellationTokenSource();
                await _func(param, cts.Token);
                return new OkObjectResult(new AuthorityConfigResponse());
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponse(ex));
            }
        }

    }

}

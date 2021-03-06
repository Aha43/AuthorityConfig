﻿using AuthorityConfig.Domain.Param;
using AuthorityConfig.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Api.Crontrollers.Templates
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostControllerTemplateWithResultParam<R, P> where P : BaseParam
    {
        private readonly Func<P, CancellationToken, Task<R>> _func;

        public PostControllerTemplateWithResultParam(Func<P, CancellationToken, Task<R>> func)
        {
            _func = func;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] P param)
        {
            try
            {
                param.Valid();
                using var cts = new CancellationTokenSource();
                var result = await _func(param, cts.Token);
                return new OkObjectResult(new AuthorityConfigResponseWithData<R>(result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new AuthorityConfigResponseWithData<R>(ex));
            }
        }

    }

}

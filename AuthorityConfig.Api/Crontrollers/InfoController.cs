using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthorityConfig.Api.Crontrollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new Info());
        }
    }

    class Info
    {
        public string Version => typeof(InfoController).Assembly.GetName().Version.ToString();
        public string Name => "AuthorityConfig API";
    }

}

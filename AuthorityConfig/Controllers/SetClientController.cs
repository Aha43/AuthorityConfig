﻿using AuthorityConfig.Controllers.Templates;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using Microsoft.AspNetCore.Mvc;

namespace AuthorityConfig.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetClientController : ControllerTemplate<SetClientParam>
    {
        public SetClientController(IAuthorityManager authorityManager) : base(authorityManager.SetClientAsync) { }
    }
}

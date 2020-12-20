﻿using AuthorityConfig.Domain.Param;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Business
{
    public interface IApiScopeManager
    {
        Task<IEnumerable<ApiScope>> GetApiScopesAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task AddApiScopeAsync(AddApiParam param, CancellationToken cancellationToken);
    }
}
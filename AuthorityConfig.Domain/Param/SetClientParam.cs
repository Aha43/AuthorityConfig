﻿namespace AuthorityConfig.Domain.Param
{
    public class SetClientParam
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string GrantTypesToAdd { get; set; }
        public string SharedSecret { get; set; }
        public string ScopesToAdd { get; set; }
    }
}

using AuthorityConfig.Domain.Exceptions;
using System.Collections.Generic;

namespace AuthorityConfig.Domain.Param
{
    public class GatApiScopeParam : BaseParam
    {
        public string Authority { get; set; }
        public string Name { get; set; }

        public override void Valid()
        {
            var l = new List<string>();
            if (string.IsNullOrEmpty(Authority)) l.Add(nameof(Authority));
            if (string.IsNullOrEmpty(Name)) l.Add(nameof(Name));
            if (l.Count > 0)
            {
                throw new InvalidParamException("Missing: " + string.Join(',', l));
            }
        }

    }

}

using AuthorityConfig.Domain.Exceptions;
using System.Collections.Generic;

namespace AuthorityConfig.Domain.Param
{
    public class GetClientParam : BaseParam
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }

        public override void Valid()
        {
            var l = new List<string>();
            if (string.IsNullOrEmpty(Authority)) l.Add(nameof(Authority));
            if (string.IsNullOrEmpty(ClientId)) l.Add(nameof(ClientId));
            if (l.Count > 0)
            {
                throw new InvalidParamException("Missing: " + string.Join(',', l));
            }
        }

    }

}

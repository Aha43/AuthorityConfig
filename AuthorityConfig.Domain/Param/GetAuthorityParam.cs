using AuthorityConfig.Domain.Exceptions;

namespace AuthorityConfig.Domain.Param
{
    public class GetAuthorityParam : BaseParam
    {
        public string Authority { get; set; }

        public override void Valid()
        {
            if (string.IsNullOrEmpty(Authority))
            {
                throw new InvalidParamException("Missing: " + nameof(Authority));
            }
        }

    }

}

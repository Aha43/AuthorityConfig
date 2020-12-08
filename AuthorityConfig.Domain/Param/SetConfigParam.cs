using AuthorityConfig.Domain.Model;

namespace AuthorityConfig.Domain.Param
{
    public class SetConfigParam
    {
        public string Authority { get; set; }
        public IdserverConfig Config { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
    }
}

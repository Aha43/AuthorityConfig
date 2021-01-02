using AuthorityConfig.Domain.Model;

namespace AuthorityConfig.Domain.Param
{
    public class SetConfigParam
    {
        public bool DryRun { get; set; }
        public string Authority { get; set; }
        public object Config { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
    }
}

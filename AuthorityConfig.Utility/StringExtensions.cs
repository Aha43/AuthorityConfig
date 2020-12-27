using System;

namespace AuthorityConfig.Utility
{
    public static class StringExtensions
    {
        public static string ValidAbsoluteUri(this string uri)
        {
            if (!Uri.TryCreate(uri, UriKind.Absolute, out _))
            {
                throw new Exception("Not valid absolute uri: " + uri);
            }
            return uri;
        }

    }

}

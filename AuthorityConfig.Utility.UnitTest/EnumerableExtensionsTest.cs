using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuthorityConfig.Utility.UnitTest
{
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void ShouldAddToNullReferencedEnumerable()
        {
            IEnumerable<string> enumerable = null;

            enumerable = enumerable.Extend("string");

            Assert.NotNull(enumerable);
            Assert.Single(enumerable);
            Assert.Equal("string", enumerable.First());
        }

        [Fact]
        public void ShouldAddToNonNullEmptyReferencedEnumerable()
        {
            var enumerable = new string[] { };

            var extended = enumerable.Extend("string");

            Assert.NotNull(enumerable);
            Assert.True(enumerable.Count() == 0);

            Assert.NotNull(extended);
            Assert.Single(extended);
            Assert.Contains("string1", extended);
            Assert.Contains("string2", extended);

            Assert.True(enumerable != extended);
        }

        [Fact]
        public void ShouldAddToNonNullReferencedEnumerable()
        {
            var enumerable = new string[]
            {
                "string1"
            };

            var extended = enumerable.Extend("string2");

            Assert.NotNull(enumerable);
            Assert.Single(enumerable);
            Assert.Contains("string1", enumerable);

            Assert.NotNull(extended);
            Assert.True(2 == extended.Count());
            Assert.Contains("string1", extended);
            Assert.Contains("string2", extended);

            Assert.True(enumerable != extended);
        }



    }

}

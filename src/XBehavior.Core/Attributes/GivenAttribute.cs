
using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class GivenAttribute: AttributeBase
    {
        public override string DisplayName => $"Given {Description}";

        public GivenAttribute(string description, int order)
            :base(description, order)
        {
        }
    }
}

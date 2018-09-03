using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class WhenAttribute: AttributeBase
    {
        public override string DisplayName => $"When {Description}";

        public WhenAttribute(string description, int order)
            :base(description, order)
        {
        }
    }
}

using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class ThenAttribute: AttributeBase
    {
        public override string DisplayName => $"Then {Description}";

        public ThenAttribute(string description, int order)
            :base(description, order)
        {
        }
    }
}

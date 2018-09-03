using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class AttributeBase: FactAttribute
    {
        protected readonly string Description;
        public int Order { get; }
        public override string Skip => string.Empty;

        protected AttributeBase(string description, int order)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException($"{nameof(description)} is not valid.");

            Order = order;
            Description = description;
        }
    }
}

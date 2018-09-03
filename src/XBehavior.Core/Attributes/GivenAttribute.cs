
using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class GivenAttribute: FactAttribute
    {
        private readonly string _description;

        public override string DisplayName => _description;
        public override string Skip => string.Empty;

        public GivenAttribute(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException($"{nameof(description)} is not valid.");

            _description = description;
        }
    }
}

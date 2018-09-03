﻿
using System;

using Xunit;

namespace XBehavior.Core.Attributes
{
    public class GivenAttribute: FactAttribute
    {
        private readonly string _description;
        public int Order { get; }
        public override string DisplayName => $"Given {_description}";
        public override string Skip => string.Empty;

        public GivenAttribute(string description, int order)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException($"{nameof(description)} is not valid.");

            Order = order;
            _description = description;
        }
    }
}

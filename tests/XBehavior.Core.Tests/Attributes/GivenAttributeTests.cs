using System;

using FluentAssertions;

using XBehavior.Core.Attributes;

using Xunit;

namespace XBehavior.Core.Tests.Attributes
{
    public class GivenAttributeTests
    {
        [Fact]
        public void GivenAttribute_IsOfTypeFactAttribute()
        {
            GivenAttribute sut = new GivenAttribute("test", 1);
            sut.GetType().BaseType.Name.Should().Be(nameof(FactAttribute));
        }

        [Fact]
        public void GivenAttribute_AllowsToSpecifyOrder()
        {
            int expectedOrder = 1;
            GivenAttribute sut = new GivenAttribute("test", expectedOrder);
            sut.Order.Should().Be(expectedOrder);
        }

        [Fact]
        public void GivenAttribute_SetsCorrectDescriptionAsDisplayName()
        {
            string description = "A sample attribute description.";
            GivenAttribute sut = new GivenAttribute(description, 1);
            sut.DisplayName.Should().Be($"Given {description}");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenAttribute_WithDescriptionNameAsIndicated_ThrowsException(string description)
        {
            Action exceptionThrowingAction = () => new GivenAttribute(description, 1);
            exceptionThrowingAction.Should().Throw<ArgumentException>()
                                   .Which.Message.Should().Contain("description is not valid.");
        }

        [Fact]
        public void GivenAttribute_SkipDescriptionIsAlwaysEmpty()
        {
            GivenAttribute sut = new GivenAttribute("test", 1);
            sut.Skip.Should().BeEmpty();
        }
    }
}

using System;

using FluentAssertions;

using XBehavior.Core.Attributes;

using Xunit;

namespace XBehavior.Core.Tests.Attributes
{
    public class WhenAttributeTests
    {
        [Fact]
        public void WhenAttribute_AllowsToSpecifyOrderOfExecution()
        {
            int expectedOrder = 1;
            WhenAttribute sut = new WhenAttribute("test", expectedOrder);
            sut.Order.Should().Be(expectedOrder);
        }

        [Fact]
        public void WhenAttribute_SetsCorrectDescriptionAsDisplayName()
        {
            string description = "attribute description.";
            WhenAttribute sut = new WhenAttribute(description, 1);
            sut.DisplayName.Should().Be($"When {description}");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenAttribute_WithDescriptionNameAsIndicated_ThrowsException(string description)
        {
            Action exceptionThrowingAction = () => new WhenAttribute(description, 1);
            exceptionThrowingAction.Should().Throw<ArgumentException>()
                                   .Which.Message.Should().Contain("description is not valid.");
        }

        [Fact]
        public void WhenAttribute_SkipDescriptionIsAlwaysEmpty()
        {
            WhenAttribute sut = new WhenAttribute("test", 1);
            sut.Skip.Should().BeEmpty();
        }
    }
}

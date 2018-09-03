using System;

using FluentAssertions;

using XBehavior.Core.Attributes;

using Xunit;

namespace XBehavior.Core.Tests.Unit.Attributes
{
    public class ThenAttributeTests
    {

        [Fact]
        public void ThenAttribute_AllowsToSpecifyOrderOfExecution()
        {
            int expectedOrder = 1;
            ThenAttribute sut = new ThenAttribute("test", expectedOrder);
            sut.Order.Should().Be(expectedOrder);
        }

        [Fact]
        public void ThenAttribute_SetsCorrectDescriptionAsDisplayName()
        {
            string description = "attribute description.";
            ThenAttribute sut = new ThenAttribute(description, 1);
            sut.DisplayName.Should().Be($"Then {description}");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThenAttribute_WithDescriptionNameAsIndicated_ThrowsException(string description)
        {
            Action exceptionThrowingAction = () => new ThenAttribute(description, 1);
            exceptionThrowingAction.Should().Throw<ArgumentException>()
                                   .Which.Message.Should().Contain("description is not valid.");
        }

        [Fact]
        public void ThenAttribute_SkipDescriptionIsAlwaysEmpty()
        {
            ThenAttribute sut = new ThenAttribute("test", 1);
            sut.Skip.Should().BeEmpty();
        }
    }
}

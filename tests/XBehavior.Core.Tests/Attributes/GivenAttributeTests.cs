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
            GivenAttribute sut = new GivenAttribute(string.Empty);
            sut.GetType().BaseType.Name.Should().Be(nameof(FactAttribute));
        }

        [Fact]
        public void GivenAttribute_CanAcceptDisplayName()
        {
            string givenAttributeDescription = "given attribute description.";
            GivenAttribute sut = new GivenAttribute(givenAttributeDescription);
            sut.DisplayName.Should().Be(givenAttributeDescription);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenAttribute_WithDescriptionNameAsIndicated_ThrowsException(string description)
        {
            Action exceptionThrowingAction = () => new GivenAttribute(description);
            exceptionThrowingAction.Should().Throw<ArgumentException>()
                                   .Which.Message.Should().Contain("description is not valid.");
        }

        [Fact]
        public void GivenAttribute_SkipDescriptionIsAlwaysEmpty()
        {
            GivenAttribute sut = new GivenAttribute("test");
            sut.Skip.Should().BeEmpty();
        }
    }
}

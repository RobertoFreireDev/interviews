using FluentAssertions;
using Hash.Example;
using Xunit;

namespace Hash.Test
{
    public class SecretMessageTest
    {
        [Fact]
        public void Must_Create_And_Verify_Message()
        {
            var secretMessage = new SecretMessage();
            var message = "abc";

            secretMessage.Set(message);
            var result = secretMessage.Verify(message);

            result.Should().BeTrue();
        }
    }
}
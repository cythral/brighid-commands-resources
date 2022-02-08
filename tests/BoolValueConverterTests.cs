using System.Text.Json;

using FluentAssertions;

using NUnit.Framework;

namespace Brighid.Commands.Resources
{
    [Category("Unit")]
    public class BoolValueConverterTests
    {
        [Test, Auto]
        public void ShouldDeserializeTrueValueFromString()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new BoolValueConverter());
            var result = JsonSerializer.Deserialize<bool>(@"""true""", options);

            result.Should().BeTrue();
        }

        [Test, Auto]
        public void ShouldDeserializeFalseValueFromString()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new BoolValueConverter());
            var result = JsonSerializer.Deserialize<bool>(@"""false""", options);

            result.Should().BeFalse();
        }

        [Test, Auto]
        public void ShouldDeserializeTrueValueFromLiteral()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new BoolValueConverter());
            var result = JsonSerializer.Deserialize<bool>(@"true", options);

            result.Should().BeTrue();
        }

        [Test, Auto]
        public void ShouldDeserializeFalseValueFromLiteral()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new BoolValueConverter());
            var result = JsonSerializer.Deserialize<bool>(@"false", options);

            result.Should().BeFalse();
        }
    }
}

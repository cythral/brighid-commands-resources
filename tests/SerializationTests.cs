using System.Text.Json;

using FluentAssertions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

#pragma warning disable SA1602

namespace Brighid.Commands.Resources
{
    [Category("Unit")]
    public class SerializationTests
    {
        public enum TestEnum : int
        {
            A = 0,
            B = 1,
        }

        [Test, Auto]
        public void EnumsShouldSerializeFromStrings()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build();

            services.AddSingleton<IConfiguration>(configuration);
            new Startup(configuration).ConfigureServices(services);

            var options = services.BuildServiceProvider().GetRequiredService<JsonSerializerOptions>();
            var result = JsonSerializer.Deserialize<TestEnum>("\"1\"", options);

            result.Should().Be(TestEnum.B);
        }
    }
}

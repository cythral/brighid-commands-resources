using System.Text.Json;
using System.Text.Json.Serialization;

using Lambdajection.Core;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brighid.Commands.Resources
{
    /// <inheritdoc />
    public class Startup : ILambdaStartup
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration">Configuration to use when configuring startup services.</param>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <inheritdoc />
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureBrighidIdentity<IdentityConfig>(configuration.GetSection("Identity"));
            services.AddBrighidCommands(configuration.GetSection("Commands").Bind);
            services.AddSingleton(CreateJsonOptions());
        }

        private static JsonSerializerOptions CreateJsonOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString,
            };

            options.Converters.Add(new BoolValueConverter());
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}

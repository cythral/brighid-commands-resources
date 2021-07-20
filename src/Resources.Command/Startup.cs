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
            services.ConfigureBrighidIdentity(configuration.GetSection("Identity"));
            services.AddBrighidCommands(configuration.GetSection("Commands").Bind);
        }
    }
}

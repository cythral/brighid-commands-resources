using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Brighid.Commands.Client;

using Lambdajection.Attributes;
using Lambdajection.CustomResource;

using Microsoft.Extensions.Logging;

namespace Brighid.Commands.Resources
{
    /// <summary>
    /// Custom resource handler for commands.
    /// </summary>
    [CustomResourceProvider(typeof(Startup))]
    public partial class CommandHandler
    {
        private readonly ICommandsClient commandsClient;
        private readonly ClientRequestOptions requestOptions = default;
        private readonly ILogger<CommandHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler" /> class.
        /// </summary>
        /// <param name="commandsClient">Client to use for interacting with the commands service.</param>
        /// <param name="logger">Logger used to log information to stdout.</param>
        public CommandHandler(
            ICommandsClient commandsClient,
            ILogger<CommandHandler> logger
        )
        {
            this.commandsClient = commandsClient;
            this.logger = logger;
        }

#pragma warning disable IDE0060

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for creating a command.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Create(CustomResourceRequest<CommandRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received create request: {@request}", JsonSerializer.Serialize(request));
            var result = await commandsClient.CreateCommand(request.ResourceProperties, requestOptions, cancellationToken);
            return new OutputData { Id = result.Name };
        }

        /// <summary>
        /// Updates an existing command.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating a command.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Update(CustomResourceRequest<CommandRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received update request: {@request}", JsonSerializer.Serialize(request));
            var result = await commandsClient.UpdateCommand(request.PhysicalResourceId, request.ResourceProperties, requestOptions, cancellationToken);
            return new OutputData { Id = result.Name };
        }

        /// <summary>
        /// Updates an existing command.
        /// </summary>
        /// <param name="request">Data to pass to the commands service for updating a command.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>The resulting command data.</returns>
        public async Task<OutputData> Delete(CustomResourceRequest<CommandRequest> request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Received delete request: {@request}", JsonSerializer.Serialize(request));
            var result = await commandsClient.DeleteCommand(request.PhysicalResourceId, requestOptions, cancellationToken);
            return new OutputData { Id = result.Name };
        }
    }
}

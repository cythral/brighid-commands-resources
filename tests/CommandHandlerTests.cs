using System.Threading;
using System.Threading.Tasks;

using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;

using Brighid.Commands.Client;

using FluentAssertions;

using Lambdajection.CustomResource;

using NSubstitute;

using NUnit.Framework;

using static NSubstitute.Arg;

namespace Brighid.Commands.Resources
{
    public class CommandHandlerTests
    {
        [TestFixture]
        [Category("Unit")]
        public class CreateTests
        {
            [Test, Auto]
            public async Task ShouldCreateCommandWithResourceProperties(
                CustomResourceRequest<CommandRequest> request,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                await handler.Create(request, cancellationToken);

                await commandsClient.Received().CreateCommand(Is(request.ResourceProperties), Is(default(ClientRequestOptions)), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnOutputDataWithNameAsId(
                CustomResourceRequest<CommandRequest> request,
                [Frozen] Command command,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Create(request, cancellationToken);

                result.Id.Should().Be(command.Name);
            }
        }

        [TestFixture]
        [Category("Unit")]
        public class UpdateTests
        {
            [Test, Auto]
            public async Task ShouldUpdateCommandWithResourceProperties(
                CustomResourceRequest<CommandRequest> request,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                await handler.Update(request, cancellationToken);

                await commandsClient.Received().UpdateCommand(Is(request.PhysicalResourceId), Is(request.ResourceProperties), Is(default(ClientRequestOptions)), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnOutputDataWithNameAsId(
                CustomResourceRequest<CommandRequest> request,
                [Frozen] Command command,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Update(request, cancellationToken);

                result.Id.Should().Be(command.Name);
            }
        }

        [TestFixture]
        [Category("Unit")]
        public class DeleteTests
        {
            [Test, Auto]
            public async Task ShouldCreateCommandWithResourceProperties(
                CustomResourceRequest<CommandRequest> request,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                await handler.Delete(request, cancellationToken);

                await commandsClient.Received().DeleteCommand(Is(request.PhysicalResourceId), Is(default(ClientRequestOptions)), Is(cancellationToken));
            }

            [Test, Auto]
            public async Task ShouldReturnOutputDataWithNameAsId(
                CustomResourceRequest<CommandRequest> request,
                [Frozen] Command command,
                [Frozen, Substitute] ICommandsClient commandsClient,
                [Target] CommandHandler handler,
                CancellationToken cancellationToken
            )
            {
                var result = await handler.Delete(request, cancellationToken);

                result.Id.Should().Be(command.Name);
            }
        }
    }
}

using Lambdajection.Attributes;
using Lambdajection.Encryption;

namespace Brighid.Commands.Resources
{
    /// <summary>
    /// Options to use for Brighid Identity.
    /// </summary>
    [LambdaOptions(typeof(CommandHandler), "Identity")]
    public class IdentityConfig : Identity.Client.IdentityConfig
    {
        /// <summary>
        /// Gets or sets the Identity Client Secret.
        /// </summary>
        [Encrypted]
        public override string ClientSecret { get; set; } = string.Empty;
    }
}

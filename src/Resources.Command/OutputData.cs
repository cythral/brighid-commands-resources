using Lambdajection.CustomResource;

namespace Brighid.Commands.Resources
{
    /// <summary>
    /// Represents data returned to CloudFormation about a command.
    /// </summary>
    public class OutputData : ICustomResourceOutputData
    {
        /// <summary>
        /// Gets or sets the command's id/name in string form.
        /// </summary>
        public string Id { get; set; } = string.Empty;
    }
}

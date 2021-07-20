using Brighid.Commands.Client;

using Lambdajection.CustomResource;

namespace Brighid.Commands.Resources
{
    /// <summary>
    /// Represents data returned to CloudFormation about a command.
    /// </summary>
    public class OutputData : Command, ICustomResourceOutputData
    {
        /// <summary>
        /// Gets the command's id/name in string form.
        /// </summary>
        public new string Id => Name;
    }
}

using System;
using System.Threading.Tasks;

namespace Orion.Net.Core.Interfaces
{
    /// <summary>
    /// Client Script Interface
    /// </summary>
    public interface IClientScript
    {
        /// <summary>
        /// Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Unique identifier of the script
        /// </summary>
        Guid Identifier { get; }

        /// <summary>
        /// Execute the script on the client side
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task Execute(string parameters);
    }
}

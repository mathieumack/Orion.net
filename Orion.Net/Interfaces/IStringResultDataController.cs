namespace Orion.Net.Interfaces
{
    public interface IStringResultDataController
    {
        /// <summary>
        /// Return SupportId of the user
        /// </summary>
        /// <returns>Guid SupportId in String</returns>
        /// <remarks>If the key doesn't exist, save and return a new one</remarks>
        string Get();
    }
}

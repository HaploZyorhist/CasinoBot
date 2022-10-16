namespace CasinoBot.Domain.UserInformation.Requests
{
    /// <summary>
    /// Object containing data regarding requesting registration for the user
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// the id of the user being registered
        /// </summary>
        public ulong Id { get; set; }
    }
}

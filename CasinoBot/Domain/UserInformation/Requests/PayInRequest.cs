namespace CasinoBot.Domain.UserInformation.Requests
{
    /// <summary>
    /// Request for doing pay in
    /// </summary>
    public class PayInRequest
    {
        /// <summary>
        /// the id of the user
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// the amount being paid in
        /// </summary>
        public int Cost { get; set; }
    }
}

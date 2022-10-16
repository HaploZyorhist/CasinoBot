namespace CasinoBot.Domain.UserInformation.Requests
{
    /// <summary>
    /// request for adding winnings to a player
    /// </summary>
    public class PayOutRequest
    {
        /// <summary>
        /// the id of the user
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// the amount of winnings being given to the user
        /// </summary>

        public int Cash { get; set; }
    }
}

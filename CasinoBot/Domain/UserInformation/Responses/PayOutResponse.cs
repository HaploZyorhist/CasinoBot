namespace CasinoBot.Domain.UserInformation.Responses
{
    /// <summary>
    /// the response for the pay out request
    /// </summary>
    public class PayOutResponse
    {
        /// <summary>
        /// the user's cash after they were paid out
        /// </summary>
        public int Cash { get; set; }
    }
}

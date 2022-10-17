namespace CasinoBot.Domain.UserInformation.Responses
{
    /// <summary>
    /// the response for when the user pays in
    /// </summary>
    public class PayInResponse
    {
        /// <summary>
        /// the user's cash after the pay in
        /// </summary>
        public int Cash { get; set; }
    }
}

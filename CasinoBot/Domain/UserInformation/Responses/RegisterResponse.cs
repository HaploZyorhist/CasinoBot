namespace CasinoBot.Domain.UserInformation.Responses
{
    /// <summary>
    /// Response object containing the results of the registration
    /// </summary>
    public class RegisterResponse
    {
        /// <summary>
        /// the cash the user has after registration
        /// </summary>
        public int Cash { get; set; }
    }
}

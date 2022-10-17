namespace CasinoBot.Models
{
    /// <summary>
    /// Object containing data on the user
    /// </summary>
    public class UserData
    {
        //TODO: Turn this into database driven data instead of part of the concurrent dictionary
        /// <summary>
        /// The amount of cash the user has
        /// </summary>
        public int Cash { get; set; } = 1000;
    }
}

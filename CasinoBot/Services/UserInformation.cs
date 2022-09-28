using CasinoBot.Models;
using CasinoBot.Services.Interfaces;
using System.Collections.Concurrent;

namespace CasinoBot.Services
{
    /// <summary>
    /// Class for handling interactions with user information
    /// </summary>
    public class UserInformation : IUserInformation
    {
        //TODO: Turn this into a database connection instead of a concurrent dictionary
        public ConcurrentDictionary<ulong, UserData> Information = new ConcurrentDictionary<ulong, UserData>();

        /// <inheritdoc />
        public async Task Payin (int cost)
        {
            return;
        }

        /// <inheritdoc />
        public async Task Payout (int winnings)
        {
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoBot.Services.Interfaces
{
    /// <summary>
    /// Interface for interacting with user information
    /// </summary>
    public interface IUserInformation
    {
        /// <summary>
        /// Method for removing money from the user's wallet
        /// </summary>
        /// <param name="cost">the amount that the user is paying to play</param>
        /// <returns></returns>
        Task Payin(int cost);

        Task Payout(int winnings);
    }
}

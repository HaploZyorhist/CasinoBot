using CasinoBot.Domain.UserInformation.Requests;
using CasinoBot.Domain.UserInformation.Responses;
using CasinoBot.Models;

namespace CasinoBot.Services.Interfaces
{
    /// <summary>
    /// Interface for interacting with user information
    /// </summary>
    public interface IUserInformation
    {
        /// <summary>
        /// Method for registering a user to the system
        /// </summary>
        /// <param name="request">request object containing data for the registration of the user</param>
        /// <returns>response object containing the results of the request</returns>
        Task<Response<RegisterResponse>> Register(RegisterRequest request);

        /// <summary>
        /// Method for removing money from the user's wallet
        /// </summary>
        /// <param name="request">object containing data on paying in for the game</param>
        /// <returns>Object containing data regarding the results of the request</returns>
        Task<Response<PayInResponse>> PayIn(PayInRequest request);

        /// <summary>
        /// Method for adding money to the user's wallet
        /// </summary>
        /// <param name="request">object containing data for winning the game</param>
        /// <returns>Object containing data regarding the results of the request</returns>
        Task<Response<PayOutResponse>> PayOut(PayOutRequest request);
    }
}

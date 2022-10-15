using CasinoBot.Domain.UserInformation.Requests;
using CasinoBot.Domain.UserInformation.Responses;
using CasinoBot.Models;
using CasinoBot.Services.Interfaces;
using Discord;
using Discord.Net;
using System.Collections.Concurrent;

namespace CasinoBot.Services
{
    /// <summary>
    /// Class for handling interactions with user information
    /// </summary>
    public class UserInformation : IUserInformation
    {
        /// <summary>
        /// object containing data regarding the state of the user
        /// </summary>
        public ConcurrentDictionary<ulong, UserData> Information = new ConcurrentDictionary<ulong, UserData>();

        /// <inheritdoc />
        public async Task<Response<PayInResponse>> PayIn (PayInRequest request)
        {
            try
            {
                var userCash = Information.GetOrAdd(request.Id, new UserData
                {
                    Cash = 1000
                });

                if (request.Cost > userCash.Cash)
                {
                    throw new Exception($"<@{request.Id}> does not have enough money to play this game");
                }

                userCash.Cash -= userCash.Cash - request.Cost;

                var response = new PayInResponse
                {
                    Cash = userCash.Cash
                };

                return Response<PayInResponse>.Success(response);
            }
            catch (Exception ex)
            {
                return Response<PayInResponse>.Error(ex.Message);
            }
        }

        /// <inheritdoc />
        public async Task<Response<PayOutResponse>> PayOut (PayOutRequest request)
        {
            try
            {
                var userCash = Information.GetOrAdd(request.Id, new UserData
                {
                    Cash = 1000
                });

                userCash.Cash += request.Cash;

                var response = new PayOutResponse
                {
                    Cash = userCash.Cash
                };

                return Response<PayOutResponse>.Success(response);
            }
            catch (Exception ex)
            {
                return Response<PayOutResponse>.Error(ex.Message);
            }
        }
    }
}

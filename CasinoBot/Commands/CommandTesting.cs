using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoBot.Services.Interfaces;
using CasinoBot.Domain.UserInformation.Requests;
using CasinoBot.Models;

namespace CasinoBot.Commands
{
    /// <summary>
    /// Group of basic test
    /// </summary>
    [RequireUserPermission(GuildPermission.Administrator)]
    [Group("Test")]
    [Summary("Class for generating method tests")]
    public class CommandTesting : ModuleBase
    {
        #region Fields

        public IUserInformation _userInfo;

        #endregion

        #region CTOR

        /// <summary>
        /// constructor for the method
        /// </summary>
        /// <param name="userInfo">object containing user information methods</param>
        public CommandTesting(IUserInformation userInfo)
        {
            _userInfo = userInfo;
        }

        #endregion

        #region Commands

        [Command("Register")]
        [Summary("This command is used for testing creating a new wallet for users")]
        public async Task TestRegisterUserCommand()
        {
            var context = Context;
            var user = context.User;

            try
            {
                var request = new RegisterRequest
                {
                    Id = user.Id,
                };

                var result = await _userInfo.Register(request);

                if(result.Status != Status.Success)
                {
                    throw new Exception(result.Errors?.ToString());
                }

                var sb = new StringBuilder();
                sb.AppendLine($"{nameof(TestRegisterUserCommand)} has been hit");
                sb.AppendLine($"<@{request.Id}> has been registered and has {result.Result.Cash} available");

                await ReplyAsync(sb.ToString());
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        [Command("Ante")]
        [Summary("This command is used for testing the paying of the ante cost")]
        public async Task TestAnteCommand(params string[] args)
        {
            var context = Context;
            var user = context.User;

            try
            {
                if (!int.TryParse(args[0], out int ante))
                {
                    throw new Exception("Please enter a valid number for the Ante");
                }

                var request = new PayInRequest
                {
                    Id = user.Id,
                    Cost = ante
                };

                var result = await _userInfo.PayIn(request);

                if(result.Status != Status.Success)
                {
                    throw new Exception(result.Messages?.ToString());
                }

                var sb = new StringBuilder();

                sb.AppendLine($"{nameof(TestAnteCommand)} has been hit");
                sb.AppendLine($"<@{request.Id}> has {result.Result.Cash} remaining");
                await ReplyAsync(sb.ToString());
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        [Command("Win")]
        [Summary("This command is used for testing the game payouts")]
        public async Task TestPayoutCommand(params string[] args)
        {
            var context = Context;
            var user = context.User;

            try
            {
                if (!int.TryParse(args[0], out int winnings))
                {
                    throw new Exception("Please enter a valid number for the Winnings");
                }

                var request = new PayOutRequest
                {
                    Id = user.Id,
                    Cash = winnings
                };

                var result = await _userInfo.PayOut(request);

                if (result.Status != Status.Success)
                {
                    throw new Exception(result.Messages?.ToString());
                }

                var sb = new StringBuilder();

                sb.AppendLine($"{nameof(TestAnteCommand)} has been hit");
                sb.AppendLine($"<@{request.Id}> has {result.Result.Cash} remaining");
                await ReplyAsync(sb.ToString());
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        #endregion
    }
}
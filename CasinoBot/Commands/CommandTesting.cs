using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoBot.Services.Interfaces;

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
                await ReplyAsync($"{nameof(TestRegisterUserCommand)} has been hit");
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        [Command("Ante")]
        [Summary("This command is used for testing the paying of the ante cost")]
        public async Task TestAnteCommand()
        {
            var context = Context;
            try
            {
                await ReplyAsync($"{nameof(TestAnteCommand)} has been hit");
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        [Command("Payout")]
        [Summary("This command is used for testing the game payouts")]
        public async Task TestPayoutCommand()
        {
            var context = Context;
            try
            {
                await ReplyAsync($"{nameof(TestPayoutCommand)} has been hit");
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        #endregion
    }
}
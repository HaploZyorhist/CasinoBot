using System.Text;
using CasinoBot.Models.Slots;
using CasinoBot.Services.Interfaces;
using Discord;
using Discord.Commands;

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

        public ISlotMachine _slots;

        #endregion

        #region CTOR

        public CommandTesting (ISlotMachine slots)
        {
            _slots = slots;
        }

        #endregion

        #region Commands

        [Command("Slots")]
        [Summary("This command is used for testing Slots Machine")]
        public async Task TestSlotsCommand()
        {
            var context = Context;
            try
            {
                var request = new SlotMachineRequest
                {
                    NumberOfLines = 1
                };
                await _slots.Roller(context, request);
            }
            catch (Exception ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        #endregion
    }
}

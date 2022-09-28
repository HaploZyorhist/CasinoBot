using CasinoBot.Models.Slots;
using Discord.Commands;

namespace CasinoBot.Services.Interfaces
{
    public interface ISlotMachine
    {
        Task Roller(ICommandContext context, SlotMachineRequest request);
    }
}

using CasinoBot.Services.Interfaces;
using Discord.Commands;
using Discord;
using System.Text;
using CasinoBot.Models.Slots;

namespace CasinoBot.Services
{
    public class SlotMachine : ISlotMachine
    {
        public ICommandContext _context;
        public StringBuilder _messages = new StringBuilder();

        public SlotMachine()
        {
        }

        public async Task Roller(ICommandContext context, SlotMachineRequest request)
        {
            try
            {
                _context = context;

                var wheels = new Wheel[3] { new Wheel(), new Wheel(), new Wheel() };

                // fill in each of the wheels with what they rolled
                //TODO: need to change how the wheels are filled in.  Geherally wheels are preset in their
                // display order and picking what icon lands is purely a statistical chance.  will fix
                // later
                for (int wheel = 0; wheel < wheels.Count(); wheel++)
                {
                    for (int s = 0; s < wheels[wheel].Slot.Count(); s++)
                    {
                        Random r = new Random();

                        var num = r.Next(1, 6);
                        wheels[wheel].Slot[s] = (WheelIcon)num;
                    }
                }

                _messages.AppendLine($"The wheels have spun and stopped with, ");
                for (var i = 0; i < wheels.Count(); i++)
                {
                    _messages.AppendLine("\t");
                    _messages.Append(wheels[0].Slot[i].ToString() + "\t");
                    _messages.Append(wheels[1].Slot[i].ToString() + "\t");
                    _messages.Append(wheels[2].Slot[i].ToString() + "\t");
                }

                await _context.Channel.SendMessageAsync(_messages.ToString());
            }
            catch (Exception ex)
            {
                await _context.Channel.SendMessageAsync($"The roller failed to roll a number");
            }
        }
    }
}

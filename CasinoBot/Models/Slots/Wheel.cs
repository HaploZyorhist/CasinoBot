using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoBot.Models.Slots
{
    public class Wheel
    {
        public WheelIcon[] Slot { get; set; } = new WheelIcon[3] {0, 0, 0};
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoBot.Domain.UserInformation.Requests
{
    public class PayOutRequest
    {
        public ulong Id { get; set; }

        public int Cash { get; set; }
    }
}

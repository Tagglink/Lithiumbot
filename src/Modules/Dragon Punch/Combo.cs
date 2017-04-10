using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lithiumbot.Modules.Dragon_Punch
{
    public struct Combo
    {
        public string game { get; set; }
        public string character { get; set; }
        public string message { get; set; }
        public int damage { get; set; }
        public int meter { get; set; }
        public bool corner { get; set; }
        public bool general { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lithiumbot.Modules.CustomCommands {
    public class Command {
        public int CommandId { get; set; }
        public string CreatorId { get; set; }
        public string CommandName { get; set; }
        public string CommandContent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths
{
    public class User
    {
        public string UserName { get; set; } = null;
        public string password { get; set; } = null;
        public string avatarImg { get; set; } = null;
        public string level { get; set; } = null;
        public string currentProgress { get; set; } = null;
        public string lastSessions { get; set; } = null;
    }
}

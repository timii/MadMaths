
namespace MadMaths
{
    public class User
    {
        public string UserName { get; set; } = null;
        public string password { get; set; } = null;
        public string avatarImg { get; set; } = null;
        public int level { get; set; } = 1;
        public int currentProgress { get; set; } = 0;
        public string lastSessions { get; set; } = null;
    }

    public class UserRank
    {
        public string UserName { get; set; }
        public int? progress { get; set; }
    }
}

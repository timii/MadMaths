using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MadMaths
{
    public class User
    {
        public string UserName { get; set; } = null;
        public string password { get; set; } = null;
        public string avatarImg { get; set; } = null;
        public int level { get; set; } = 1;
        public int currentProgress { get; set; } = 0;
        public Queue<string> lastSessions { get; set; } = new Queue<string>();
        public int grundschule { get; set; }
        public int mittelstufe { get; set; }
        public int oberstufe { get; set; }
    }

    public class UserRank
    {
        public string UserName { get; set; }
        public int Points { get; set; }
        private BitmapImage AvatarImg = new BitmapImage(new Uri("../assets/icons/profile-picture-icon.jpg", UriKind.Relative));
        public BitmapImage avatarImg
        {
            get { return AvatarImg; }
            set
            {
                if (value != null)
                {
                    AvatarImg = value;
                }
            }
        }
        public int rank { get; set; }
        public string RankColor { get; set; } = "#FF01C8FF";
    }
}

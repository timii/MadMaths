
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
        public string lastSessions { get; set; } = null;
    }

    public class UserRank
    {
        public string UserName { get; set; }
        public int Points { get; set; }
        public BitmapImage avatarImg { get; set; }
    }
    /// <summary>
    /// Hier wird die Anzahl richtig beantworteter Aufgaben der letzten Sitzung
    /// gespeichert
    /// </summary>
    public struct Challenge
    {
        public int grundschule { get; set; }
        public int mittelstufe { get; set; }
        public int oberstufe { get; set; }
    }
}

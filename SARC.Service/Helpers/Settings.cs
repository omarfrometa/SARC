using System;
namespace SARC.Service.Helpers
{
    public class Settings
    {
        public static string ConnectionString { get; private set; }

        public static void SetConString(string _conString)
        {
            ConnectionString = _conString;
        }
    }
}

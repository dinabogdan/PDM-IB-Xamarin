using Xamarin.Forms;

namespace InternetBanking.Utils
{
    public class Constants
    {
        static Color backgroundColor = Color.FromRgb(230, 230, 250);
        private static Color mainTextColor = Color.White;

        private static int loginIconHeight = 90;
        private static int dashboardIconHeight = 200;

        private static string currency = "RON";

        
        public static Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public static Color MainTextColor { get => mainTextColor; set => mainTextColor = value; }
        public static int LoginIconHeight { get => loginIconHeight; set => loginIconHeight = value; }
        public static int DashboardIconHeight { get => dashboardIconHeight; set => dashboardIconHeight = value; }
        public static string Currency { get => currency; set => currency = value; }

        public static string NoInternetText = "No Internet, please check the connection!";


        //-----Login Path----//
        public static string LoginUrl = "https://test.com/api/Auth/Login";

        public static string UsersUrl = "https://api.myjson.com/bins/ifncy";
    }
}

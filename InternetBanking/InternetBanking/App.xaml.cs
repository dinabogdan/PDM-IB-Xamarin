using InternetBanking.Data;
using InternetBanking.Model;
using InternetBanking.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace InternetBanking
{
	public partial class App : Application
	{
        static UserDatabaseController userDatabase;
        static HistoryStateDatabaseController historyState;
        static RestService restService;
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static bool noInterShow;
        private static object timer;
        private static User currentUser;

        public App ()
		{
			InitializeComponent();

            MainPage = new Views.LoginPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }

        
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        public static HistoryStateDatabaseController HistoryStateDatabaseController
        {
            get
            {
                if (historyState == null)
                {
                    historyState = new HistoryStateDatabaseController();
                }
                return historyState;
            }
        }

        public static User CurrentUser { get => currentUser; set => currentUser = value; }


        //------Internet Connection-----//

        public static void StartCheckForInternetConnection(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.checkNetworkConnection();
            if (!networkConnection.isConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlertAsync();
                        }
                    }
                });
            } else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }

        public static async Task<bool> CheckForInternetWithAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.checkNetworkConnection();
            if(!networkConnection.isConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlertAsync();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlertAsync()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has no internet", "Ok");
            noInterShow = false;
        }
    }
}

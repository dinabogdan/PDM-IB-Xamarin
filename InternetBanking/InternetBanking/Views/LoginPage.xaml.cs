using InternetBanking.Model;
using InternetBanking.Utils;
using InternetBanking.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternetBanking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            createSomeFakeUsers();
            Init();
		}

        void Init()
        {
            LogoStack.HeightRequest = this.Height *  1 / 2;
            BackgroundColor = Constants.BackgroundColor;
            lblUsername.TextColor = Constants.MainTextColor;
            lblPassword.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            App.StartCheckForInternetConnection(lblInternet, this);

            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => SignInProcedureAsync(s, e);
        }

        void createSomeFakeUsers()
        {
            App.UserDatabase.DeleteAllFromDatabase();

            User user1 = new User("Sebi95", "SebiTest");
            User user2 = new User("Dina95", "DinaTest");
            User user3 = new User("Chiha95", "ChihaTest");
            App.UserDatabase.SaveUser(user1);
            App.UserDatabase.SaveUser(user2);
            App.UserDatabase.SaveUser(user3);
        }

        async Task SignInProcedureAsync(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);
            if (App.UserDatabase.GetUserByUsernameAndPassword(user) != null)
            {
                                          
                App.CurrentUser = user;


                Application.Current.MainPage = new MasterDetail();
               
                           
                
            }
            else
            {
               await DisplayAlert("Login", "Incorrect credentials. If persists, contact your bank administration", "Ok");
            }
        }
    }
}
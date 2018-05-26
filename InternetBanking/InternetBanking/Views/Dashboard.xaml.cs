using InternetBanking.Model;
using InternetBanking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace InternetBanking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
	{
        private Account currentAccount;

		public Dashboard ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {

            DashboardStack.HeightRequest = this.Height * 1 / 3;
            BackgroundColor = Constants.BackgroundColor;
            var accounts = App.RestService.GetUserAccounts();
            foreach (var account in App.RestService.Items)
            {
                if (account.UserName.Equals(App.CurrentUser.Username))
                {
                    currentAccount = account;
                    lblUserAmount.Text = account.TotalBalance.ToString() + " " + Constants.Currency;
                    lblSavings.Text = account.SavingBalance.ToString() + " " + Constants.Currency;
                }
            }
        }

        void SaveCurrentState(object sender, EventArgs e) {
            HistoryState historyState = new HistoryState();
            historyState.Date = DateTime.Now;
            historyState.DifferenceAmount = Convert.ToDecimal(currentAccount.TotalBalance) - Convert.ToDecimal(currentAccount.SavingBalance);
            historyState.Currency = "RON";
            historyState.UserId = App.CurrentUser.Id;
            App.HistoryStateDatabaseController.SaveHistoryState(historyState);
            DisplayAlert("Saving state", "Current state saved. It will be available in History menu.", "Ok");
        }

    }
}
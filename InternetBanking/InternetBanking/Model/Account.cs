using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    public class Account
    {
        private string userName;
        private decimal totalBalance;
        private decimal savingBalance;

        public Account(string userName, decimal totalBalance, decimal savingBalance)
        {
            this.UserName = userName;
            this.totalBalance = totalBalance;
            this.savingBalance = savingBalance;
        }

        public decimal TotalBalance { get => totalBalance; set => totalBalance = value; }
        public decimal SavingBalance { get => savingBalance; set => savingBalance = value; }
        public string UserName { get => userName; set => userName = value; }

        public Account()
        {
        }

        public Account(decimal totalBalance, decimal savingBalance)
        {
            this.TotalBalance = totalBalance;
            this.SavingBalance = savingBalance;
        }


    }
}

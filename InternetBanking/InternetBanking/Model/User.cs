using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    public class User
    {
        private int id;
        private String username;
        private String password;
               
        [PrimaryKey]
        [AutoIncrement]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public User()
        {

        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public Boolean CheckInformation()
        {
            return (!this.username.Equals("") && !this.password.Equals("")) ? true : false;
        }
    }
}

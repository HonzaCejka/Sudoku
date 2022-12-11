using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku_0._1
{
    internal class LoginSystem
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
        public int BestTime { get; set; }
        public bool Logged { get; set; }

        public LoginSystem()
        {
            client = new FirebaseClient(config);
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "b3z7Ph5IFMgFPoDrTaaO7ASCqlQeJoJt9EN069pD",
            BasePath = "https://sudoku-a3b97-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public void LogIn(string username,string password)
        {
            Username= username;
            Password= password;

            if (username == client.Get($@"Users/{username}").ResultAs<string>())
            {
                if (password == client.Get($@"Users/{username}/Password").ResultAs<string>())
                {
                    Logged = true;                    
                }
                else
                {
                    MessageBox.Show("wrong password");
                    Logged = false;
                }
            }
            else
            {
                MessageBox.Show("User is not in databse");
                Logged = false;
            }
        }
    }
}

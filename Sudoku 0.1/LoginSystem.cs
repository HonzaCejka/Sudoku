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

            if (username == client.Get($@"Users/{username}/Username").ResultAs<string>())
            {
                if (password == client.Get($@"Users/{username}/Password").ResultAs<string>())
                {
                    Money = client.Get($@"Users/{username}/Money").ResultAs<int>();
                    BestTime = client.Get($@"Users/{username}/BestTime").ResultAs<int>();
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
        public void Register(string username,string password)
        {
            client.Set($@"/Users/{username}/Username",username);
            client.Set($@"/Users/{username}/Password", password);
            client.Set($@"/Users/{username}/Money", 10);
            client.Set($@"/Users/{username}/BestTime", 10000);
        }

        public void Win(int time)
        {
            if (time <= 600)
            {
                client.Set($@"/Users/{Username}/Money", Money += 100);
            }
            else if (time <= 1200)
            {
                client.Set($@"/Users/{Username}/Money", Money += 50);
            }
            else
            {
                client.Set($@"/Users/{Username}/Money", Money += 10);
            }
            if (time < BestTime)
            {
                BestTime = time;
            }
        }
    }
}

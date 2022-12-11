using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Sudoku_0._1
{
    internal class GetTxt
    {
        public string line { get; set; }
        int length;
        int index;
        Random random = new Random();
        public GetTxt()
        {
            client = new FirebaseClient(config);
        }
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "b3z7Ph5IFMgFPoDrTaaO7ASCqlQeJoJt9EN069pD",
            BasePath = "https://sudoku-a3b97-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        public void GetRandString()
        {
            length = client.Get(@$"/Content/count").ResultAs<int>();
            index = random.Next(1, length);
            line = client.Get($@"/Content/C{index}").ResultAs<string>();
            line = line.Replace(" ", "0");
        }
    }
}

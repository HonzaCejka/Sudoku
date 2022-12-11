using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interakční logika pro LogWin.xaml
    /// </summary>
    public partial class LogWin : Window
    {
        LoginSystem log = new LoginSystem();
        public string username { get; set; }
        public string password { get; set; }
        public bool Logged { get; set; }
        MainWindow MainWin;
        public LogWin(MainWindow win)
        {
            InitializeComponent();
            MainWin = win;
        }

        private void Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            username = Username.Text;
            password = Password.Text;
            log.LogIn(username,password);
            if (log.Logged == true)
            {
                MessageBox.Show($"you are logged as {username}");
                Visibility= Visibility.Hidden;
                Logged= true;
                MainWin.CheckLog(Logged);
            }
        }
        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {
            username = Username.Text;
            password = Password.Text;
            log.Register(username,password);
            log.LogIn(username,password);
            if (log.Logged == true)
            {
                MessageBox.Show($"you are logged as {username}");
                Visibility = Visibility.Hidden;
                Logged = true;
                MainWin.CheckLog(Logged);
            }
        }        
    }
}

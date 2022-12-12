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
    /// Interakční logika pro Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
        
        public void build(string username,int besttime,int money)
        {
            user.Text = username;
            BestTime.Text = "Best time: " + "\n" + besttime;
            Money.Text = "Money: " + "\n" + money;
        }

        private void Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

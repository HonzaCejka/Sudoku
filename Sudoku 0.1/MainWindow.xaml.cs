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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        bool conti = false;        
        SolidColorBrush ColBrush = new SolidColorBrush(Color.FromArgb(255, 43, 91, 156));
        money Money = new money(10);
        LogWin loginwin;
        Profile prof;
        public MainWindow()
        {
            InitializeComponent();
            loginwin = new LogWin(this);
            prof= new Profile();
            if (conti == true)
            {
                Continue.Cursor = Cursors.Hand;
                Continue.Background = ColBrush;
            }
            //MoneyText.Text += Money.Money.ToString();
        }

        
        public void Build()
        {

        }

        private void Continue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void NewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Game game = new Game();            
            game.Show();
            Close();
        }

        private void MakeBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Maker maker = new Maker();
            maker.Show();
            Close();
        }

        private void Quit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            loginwin.Visibility = Visibility.Visible;          
        }
        private void Profile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            prof.Visibility = Visibility.Visible;
        }

        public void CheckLog(bool log)
        {
            if (log == true)
            {
                LogText.Text = "Profile";
                Login.MouseDown -= Login_MouseDown;
                Login.MouseDown += Profile_MouseDown;
            }
            else
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interaction logic for lose.xaml
    /// </summary>
    public partial class lose : Window
    {
        public Game game { get; set; }
        public DispatcherTimer Time { get; set; }
        bool TurnOff;
        public lose(Game game,DispatcherTimer timer)
        {
            InitializeComponent();
            this.game = game ;            
            TurnOff = true;
            Time = timer;
        }


        private void Continue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff = false;
            game.Wrong -=1;
            Time.Start();
            game.mistakes();
            Close();
        }

        private void ShowBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff = false;
            game.CanFill = false;
            game.Print();
            game.gen();
            Close();
        }

        private void NewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff = false;
            game.Clear();            
            game.Wrong = 0;
            game.ResetBoard();
            game.Build();
            game.TimeString = "00:00";
            game.m = 0;
            game.time = 0;
            Close();
        }

        private void Quit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff = false;
            game.Off = false;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            game.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (TurnOff == false)
            {

            }
            else
            {
                Application.Current.Shutdown();
            }
            
        }
    }
}

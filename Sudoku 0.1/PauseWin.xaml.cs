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
using System.Windows.Threading;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interaction logic for Pause.xaml
    /// </summary>
    public partial class PauseWin : Window
    {
        DispatcherTimer Timer;
        bool turnOff = false;
        public Game game { get; set; }
        public PauseWin(DispatcherTimer timer, Game gamewin)
        {
            InitializeComponent();
            Timer = timer;
            game = gamewin;
            print();            
            turnOff = true;
        }
        public void print()
        {
            Time.Text = $"Time: \n {game.TimeString}";
            Mistakes.Text = $"Mistakes: \n {game.Wrong}/3";
        }

        private void Continue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            turnOff = false;
            Timer.Start();
            Close();            
        }        

        private void Restart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            turnOff = false;
            game.Clear();
            game.Wrong = 0;
            game.Build();
            game.TimeString = "00:00";
            game.m = 0;
            game.time = 0;
            Close();
        }

        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            turnOff = false;
            game.Off = false;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();            
            this.Close();
            game.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (turnOff == false)
            {

            }
            else
            {
                Timer.Start();
                Close();
            }

        }
    }
}

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
    /// Interaction logic for win.xaml
    /// </summary>
    public partial class win : Window
    {
        public Game game { get; set; }       
        MainWindow mainWindow;
        string time;
        bool TurnOff;
        public win(Game game,string Time)
        {
            InitializeComponent();
            this.game = game;
            time = Time;
            FinalTime.Text = time;
            TurnOff = true;
        }

        private void NewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff = false;
            game.Clear();
            game.Wrong = 0;
            game.Pick = 1;
            game.Build();
            game.picked();
            Close();
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TurnOff=false;
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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

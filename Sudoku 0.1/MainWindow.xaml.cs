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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[,] PoleAll = new TextBlock[9, 9];
        public MainWindow()
        {
            InitializeComponent();
            Gen();
            lol();
        }

        public void Gen()
        {
            TextBlock[] Pole = new TextBlock[9];
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {                   
                    Pole[x] = new TextBlock();
                    Main.Children.Add(Pole[x]);
                    Grid.SetColumn(Pole[x], x);
                    Grid.SetRow(Pole[x], y);
                    PoleAll[x,y]= Pole[x];
                    Pole[x].Foreground = Brushes.White;
                    Pole[x].HorizontalAlignment = HorizontalAlignment.Center;
                    Pole[x].VerticalAlignment = VerticalAlignment.Center;
                    Pole[x].FontSize = 36;
                                    
                }
            }

        }

        public void lol()
        {
            PoleAll[0, 1].Text = "0";
        }
    }
}

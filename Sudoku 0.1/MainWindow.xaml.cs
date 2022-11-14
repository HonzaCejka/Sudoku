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
        
        public MainWindow()
        {
            InitializeComponent();
            Gen();
        }

        public void Gen()
        {
            TextBlock[,] Pole = new TextBlock[9,9];
            Array.Fill(Pole, new TextBlock());
            
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Main.Children.Add(Pole[x,y]);
                    Grid.SetColumn(Pole[x,y],x);
                    Grid.SetRow(Pole[x,y],y);
                    Pole[x, y].Width = 23;
                    Pole[x,y].Height = 23;
                    Pole[x, y].Text = "lolik";
                }
                
            }
        }

    }
}

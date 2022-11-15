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
        Contnt cont = new Contnt();
        public MainWindow()
        {
            InitializeComponent();
            Gen();
            cont.build();
            GenContn();
        }

        public void Gen()
        {
            TextBlock[] Pole = new TextBlock[9];
            
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    GridLines();
                    PickerLines();
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.White);
                    rect.StrokeThickness = 1;
                    Pole[x] = new TextBlock();                                                                               
                    Pole[x].Foreground = Brushes.White;
                    Pole[x].HorizontalAlignment = HorizontalAlignment.Center;
                    Pole[x].VerticalAlignment = VerticalAlignment.Center;
                    Pole[x].FontSize = 36;                    
                    Main.Children.Add(rect);
                    Main.Children.Add(Pole[x]);                    
                    Grid.SetColumn(rect, x);
                    Grid.SetRow(rect, y);
                    Grid.SetColumn(Pole[x], x);
                    Grid.SetRow(Pole[x], y);                   
                    PoleAll[x, y] = Pole[x];
                }
            }

        }
        public void GridLines()
        {
            Rectangle bigerRect = new Rectangle();
            bigerRect.Stroke = new SolidColorBrush(Colors.White);
            bigerRect.StrokeThickness = 3;
            BigGrid.Children.Add(bigerRect);
            Grid.SetColumn(bigerRect,1);
            Grid.SetRow(bigerRect,1);

            for (int r = 0; r < 9; r += 3)
            {
                for (int i = 0; i < 9; i += 3)
                {
                    Rectangle bigRect = new Rectangle();
                    bigRect.Stroke = new SolidColorBrush(Colors.White);
                    bigRect.StrokeThickness = 2;                   
                    Main.Children.Add(bigRect);
                    Grid.SetColumn(bigRect, i);
                    Grid.SetRow(bigRect, r);
                    Grid.SetColumnSpan(bigRect, 3);
                    Grid.SetRowSpan(bigRect, 3);
                }
            }
        }
        public void GenContn()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    PoleAll[y, x].Text = cont.Contall[x, y];
                }
            }
        }
        public void PickerLines()
        {
            for (int i = 0; i < 9; i++)
            {
                Rectangle border = new Rectangle();
                border.Stroke = new SolidColorBrush(Colors.White);
                Picker.Children.Add(border);
                Grid.SetColumn(border, i);
                Grid.SetRow(border,i);
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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


/*
    otestuj to
    vygeneruj picker v code
    nastv Dif
*/
namespace Sudoku_0._1
{
    internal class GenBoard
    {
        public int Pick { get; set; }
        public int Dif { get; set; }
        public TextBlock[,] PoleAll { get; set; }
        public TextBlock[] Pole { get; set; }
        public Rectangle border { get; set; }

        Contnt cont = new Contnt(9);
        MainWindow win = new MainWindow();

        public GenBoard(int Dificulty)
        {
            Dif = Dificulty;
            PoleAll = new TextBlock[Dif,Dif];
            Pole = new TextBlock[Dif];
            Pick = 1;
        }
        public void gen()
        {
            for (int y = 0; y < Dif; y++)
            {
                for (int x = 0; x < Dif; x++)
                {
                    GridLines();
                    PickerLines();
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.White);
                    rect.StrokeThickness = 1;
                    Pole[x] = new TextBlock();
                    Pole[x].MouseDown += GridMouse;
                    Pole[x].Foreground = Brushes.White;
                    Pole[x].Width = 55;
                    Pole[x].Height = 55;
                    Pole[x].Tag = new int[2] { x, y };
                    Pole[x].HorizontalAlignment = HorizontalAlignment.Center;
                    Pole[x].VerticalAlignment = VerticalAlignment.Center;
                    Pole[x].TextAlignment = TextAlignment.Center;
                    Pole[x].FontSize = 36;
                    win.Main.Children.Add(rect);
                    win.Main.Children.Add(Pole[x]);
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

            //opravit dif
            Rectangle bigerRect = new Rectangle();
            bigerRect.Stroke = new SolidColorBrush(Colors.White);
            bigerRect.StrokeThickness = 3;
            win.Main.Children.Add(bigerRect);
            Grid.SetColumn(bigerRect, 0);
            Grid.SetRow(bigerRect, 0);
            Grid.SetColumnSpan(bigerRect, Dif);
            Grid.SetRowSpan(bigerRect, Dif);

            for (int r = 0; r < Dif; r += 3)
            {
                for (int i = 0; i < Dif; i += 3)
                {
                    Rectangle bigRect = new Rectangle();
                    bigRect.Stroke = new SolidColorBrush(Colors.White);
                    bigRect.StrokeThickness = 2;
                    win.Main.Children.Add(bigRect);
                    Grid.SetColumn(bigRect, i);
                    Grid.SetRow(bigRect, r);
                    Grid.SetColumnSpan(bigRect, 3);
                    Grid.SetRowSpan(bigRect, 3);
                }
            }
        }
        public void num1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBlock tb = sender as TextBlock;
            Pick = int.Parse(tb.Tag.ToString());
            picked();

        }

        public void GridMouse(object sender, MouseButtonEventArgs e)
        {

            TextBlock ceman = sender as TextBlock;
            int[] exos = ceman.Tag as int[];
            int x = exos[0];
            int y = exos[1];
            if (cont.Contall[y, x] == " ")
            {
                PoleAll[x, y].Text = Pick.ToString();
            }
            else
            {

            }
        }

        public void PickerLines()
        {
            for (int i = 0; i < Dif; i++)
            {
                border = new Rectangle();
                border.Stroke = new SolidColorBrush(Colors.White);
                win.Picker.Children.Add(border);
                Grid.SetColumn(border, i);
                Grid.SetRow(border, i);
            }
        }
        public void picked()
        {
            border.Stroke = new SolidColorBrush(Colors.Aqua);
            border.Fill = new SolidColorBrush(Colors.Aqua);
            border.StrokeThickness = 2;
            Grid.SetZIndex(border, -1);
            Grid.SetColumn(border, Pick - 1);
            Grid.SetRow(border, Pick - 1);
        }
    }
}

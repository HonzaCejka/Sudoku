using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
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
    /// Interaction logic for Maker.xaml
    /// </summary>
    public partial class Maker : Window
    {
        int Pick = 1;       
        public int Dif = 9;
        public TextBlock[,] PoleAll;
        public TextBlock[] Pole;
        public string[,] ctn;
        public Rectangle border;
        int[,] board;
        string BoardString;
        public bool conti =false;
        public static System.Windows.Media.SolidColorBrush Transparent { get; }
        SolidColorBrush ColBrush = new SolidColorBrush(Color.FromArgb(255, 43, 91, 156));
        Solver solver;

        
        
        public Maker()
        {            
            Pole = new TextBlock[Dif];
            PoleAll = new TextBlock[Dif, Dif];
            board = new int[Dif, Dif];
            InitializeComponent();                       
            gen();            
            picked();  
            client = new FirebaseClient(config);
        }

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "b3z7Ph5IFMgFPoDrTaaO7ASCqlQeJoJt9EN069pD",
            BasePath = "https://sudoku-a3b97-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
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
        public void SaveContn()
        {
            

        }
        public void GridLines()
        {

            //opravit dif
            Rectangle bigerRect = new Rectangle();
            bigerRect.Stroke = new SolidColorBrush(Colors.White);
            bigerRect.StrokeThickness = 3;
            Main.Children.Add(bigerRect);
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
                    Main.Children.Add(bigRect);
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
            if (Pick == 10)
            {
                PoleAll[x, y].Text = " ";
                board[y,x] = 0;
            }
            else
            {
                PoleAll[x, y].Text = Pick.ToString();
                board[y,x] = Pick;
            }
        }

        public void PickerLines()
        {
            for (int i = 0; i < Dif+1; i++)
            {
                border = new Rectangle();
                border.Stroke = new SolidColorBrush(Colors.White);
                Picker.Children.Add(border);
                Grid.SetColumn(border, i);
                Grid.SetRow(border, i);
            }
        }
        public void picked()
        {
            border.Stroke = ColBrush;
            border.Fill = ColBrush;
            border.StrokeThickness = 2;
            Grid.SetZIndex(border, -1);
            Grid.SetColumn(border, Pick - 1);
            Grid.SetRow(border, Pick - 1);
        }

        private void erase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pick = 10;            
            picked();
        }
        private void Make_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (int num in board)
            {
                BoardString += num + "";
            }
            solver = new Solver(Dif, BoardString);
            solver.convert();
            board = solver.board;
            solver.solveBoard(board);
            if (solver.done == true)
            {
                
                Add(BoardString);
            }
            else
            {
                MessageBox.Show("Nelze");
            }                      
            BoardString = "";
            clear();
            
        }
        public void clear()
        {
            for (int i = 0; i < Dif; i++)
            {
                for (int j = 0; j < Dif; j++)
                {
                    board[i, j] = 0;
                    PoleAll[i, j].Text = " ";
                }
            }
        }
        public void Add(string EndString)
        {
            int index = client.Get(@$"/Content/count").ResultAs<int>();
            client.Set($@"/Content/count",index+1);
            client.Set($@"/Content/C{index+1}", EndString);                   
        }
        private void Maker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    Pick = 1;
                    picked();
                    break;
                case Key.D2:
                    Pick = 2;
                    picked();
                    break;
                case Key.D3:
                    Pick = 3;
                    picked();
                    break;
                case Key.D4:
                    Pick = 4;
                    picked();
                    break;
                case Key.D5:
                    Pick = 5;
                    picked();
                    break;
                case Key.D6:
                    Pick = 6;
                    picked();
                    break;
                case Key.D7:
                    Pick = 7;
                    picked();
                    break;
                case Key.D8:
                    Pick = 8;
                    picked();
                    break;
                case Key.D9:
                    Pick = 9;
                    picked();
                    break;
                case Key.D0:
                    Pick = 10;
                    picked();
                    break;
                case Key.NumPad1:
                    Pick = 1;
                    picked();
                    break;
                case Key.NumPad2:
                    Pick = 2;
                    picked();
                    break;
                case Key.NumPad3:
                    Pick = 3;
                    picked();
                    break;
                case Key.NumPad4:
                    Pick = 4;
                    picked();
                    break;
                case Key.NumPad5:
                    Pick = 5;
                    picked();
                    break;
                case Key.NumPad6:
                    Pick = 6;
                    picked();
                    break;
                case Key.NumPad7:
                    Pick = 7;
                    picked();
                    break;
                case Key.NumPad8:
                    Pick = 8;
                    picked();
                    break;
                case Key.NumPad9:
                    Pick = 9;
                    picked();
                    break;
                case Key.NumPad0:
                    Pick = 10;
                    picked();
                    break;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KeyDown += new KeyEventHandler(Maker_KeyDown);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (conti == true)
            {

            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            conti = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();            
        }
    }
}

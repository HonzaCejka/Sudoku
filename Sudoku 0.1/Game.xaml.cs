using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sudoku_0._1
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public bool Off = true;
        public bool CanFill = true;
        public int mon;
        public int Pick = 1;
        public int Wrong = 0;        
        public int Maxmistakes = 3;        
        public int Dif = 9;   
        public int m = 0;
        public int time;
        public string TimeString;
        public int[,] board;
        public int[,] ctnint;
        public string[,] ctn;
        public string[,] BoardString;
        public TextBlock[,] PoleAll;
        public TextBlock[] Pole;
        public Rectangle border;
        public DispatcherTimer timer;
        public static System.Windows.Media.SolidColorBrush Transparent { get; }
        SolidColorBrush ColBrush = new SolidColorBrush(Color.FromArgb(255, 43, 91, 156));

        Solver solve;
        Contnt cont;
        lose Lost;
        win Winner;
        PauseWin pause;
        money Money;
        public Game()
        {
            Money = new money(10);
            cont = new Contnt(Dif);
            Pole = new TextBlock[Dif];
            PoleAll = new TextBlock[Dif, Dif];            
            ctn = new String[Dif,Dif];
            Lost = new lose(this,timer);                        
            ctnint = new int[Dif, Dif];
            BoardString = new string[Dif, Dif];            
            InitializeComponent();                       
            Build();                                 
        }        
        public void Build() 
        {
            solve = new Solver(Dif, cont.con);
            gen();            
            GridLines();
            mistakes();
            picked();           
            cont.build();
            solve.convert();
            board = solve.board;
            solve.solveBoard(board);
            Mistakes.Text = $"Mistakes: {Wrong}/{Maxmistakes}";
            GenContn();
            TimeText.Text = "Time: 00:00";
            MoneyText.Text += $"{Money.Money}"; 
            for (int y = 0; y < Dif; y++)
            {
                for (int x = 0; x < Dif; x++)
                {
                    BoardString[x, y] = board[x, y].ToString();
                }
            }
            StartTimer();
        }
        public void ResetBoard()
        {
            cont = new Contnt(Dif);
        }
        bool WinnerBool()
        {
            for (int x = 0; x < Dif; x++)
            {
                for (int y = 0; y < Dif; y++)
                {
                    if (ctn[x, y] != BoardString[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Wining()
        {                        
            if (WinnerBool())
            {
                Winner = new win(this, TimeString);
                timer.Stop();
                Winner.ShowDialog();                
            }
            else
            {
                return;
            }
        }
        public void StartTimer()
        {
           
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;                        
            if (time == 60)
            {
                m++;                
                time = 0;
            }
            if (m.ToString().Length<2)
            {
                if (time.ToString().Length < 2)
                {
                    TimeString = $"0{m}:0{time}";
                    TimeText.Text = $"Time: {TimeString}";
                }
                else
                {
                    TimeString = $"0{m}:{time}";
                    TimeText.Text = $"Time: {TimeString}";
                }
            }
            else
            {
                if (time.ToString().Length < 2)
                {
                    TimeString = $"{m}:0{time}";
                    TimeText.Text = $"Time: {TimeString}";
                }
                else
                {
                    TimeString = $"{m}:{time}";
                    TimeText.Text = $"Time: {TimeString}";
                }
            }                        
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
                    if (CanFill == true)
                    {
                        Pole[x].MouseDown += GridMouse;
                    }
                    else
                    {
                        Pole[x].MouseDown -= GridMouse;
                    }
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
        public void GenContn()
        {
            Array.Copy(cont.Contall,ctn,cont.Contall.Length);
            for (int y = 0; y < Dif; y++)
            {
                for (int x = 0; x < Dif; x++)
                {
                    PoleAll[y, x].Text = ctn[x, y];
                }
            }

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
        public void Print()
        {
            for (int j = 0; j < Dif; j++)
            {
                for (int i = 0; i < Dif; i++)
                {
                    Pole[i].MouseDown -= GridMouse;
                    PoleAll[i, j].Text = solve.FinalBoard[j,i].ToString().Replace(" ", "");                     
                    PoleAll[i, j].Foreground = ColBrush;
                    PoleAll[i, j].Text += cont.Contall[j,i].Replace(" ", "");
                    if (PoleAll[i,j].Text.Length >= 2)
                    {
                        PoleAll[i, j].Foreground = Brushes.White;
                        PoleAll[i,j].Text = PoleAll[i,j].Text.Remove(PoleAll[i, j].Text.Length - 1);
                    }
                }
            }
        }
        public void mistakes()
        {
            Mistakes.Text = $"Mistakes: {Wrong}/{Maxmistakes}";
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
        public void Clear()
        {
            for (int i = 0; i < Dif; i++)
            {
                for (int j = 0; j < Dif; j++)
                {
                    PoleAll[i, j].Text = "";
                    PoleAll[i, j].Background = Brushes.Transparent;                    
                }
            }
            for (int y = 1; y < Dif; y++)
            {
                border.Stroke = Brushes.Transparent;
                border.Fill = Brushes.Transparent;
                border.StrokeThickness = 2;
                Grid.SetZIndex(border, -1);
                Grid.SetColumn(border, y - 1);
                Grid.SetRow(border, y - 1);
            }
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
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
        private void Erase_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pick = 10;
            picked();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (Off == false)
            {

            }
            else
            {
                Application.Current.Shutdown();
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
            if (Pick == 10 && cont.Contall[y, x] == " ")
            {
                PoleAll[x, y].Text = " ";
                ctn[y, x] = " ";
                PoleAll[x, y].Background = Brushes.Transparent;
            }
            if (cont.Contall[y, x] == " " && Pick != 10)
            {
                PoleAll[x, y].Text = Pick.ToString();
                if (solve.FinalBoard[y, x] == Pick)
                {
                    PoleAll[x, y].Foreground = ColBrush;
                    PoleAll[x, y].Background = Brushes.Transparent;
                    ctn[y, x] = Pick.ToString();
                }
                else
                {
                    PoleAll[x, y].Foreground = Brushes.Red;
                    PoleAll[x, y].Background = Brushes.Pink;
                    Wrong++;
                    mistakes();
                    if (Wrong == Maxmistakes)
                    {
                        Lost = new lose(this,timer);
                        timer.Stop();
                        Lost.ShowDialog();

                    }
                }
            }
            else
            {

            }
            Wining();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KeyDown += new KeyEventHandler(Game_KeyDown);
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {            
            pause = new PauseWin(timer,this);
            timer.Stop();
            pause.ShowDialog();
        }
    }
}

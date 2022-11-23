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


        
        GenBoard bord = new GenBoard(9);
        Contnt cont = new Contnt(9);
        public MainWindow()
        {           
            InitializeComponent();            
            cont.build();
            bord.gen();
            bord.GridLines();
            bord.PickerLines();
            //GenContn();
            
        }

        
        private void num1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bord.num1_MouseDown(sender, e);
        }
        /*public void GenContn()
         {
             for (int y = 0; y < 9; y++)
             {
                 for (int x = 0; x < 9; x++)
                 {
                     PoleAll[y, x].Text = cont.Contall[x, y];                    
                 }
             }

         }*/





    }
}

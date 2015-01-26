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

namespace LifeTheGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            statsCanvas.Background = Brushes.LightGray;
            statsCanvas.Opacity = 0.6;
            statsLabel1.Content = "Liczba kroków: ";
            Canvas.SetZIndex(statsCanvas, 5);
            Game g = new Game(mainGrid, statsCanvas);
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                if (statsCanvas.Opacity != 0)
                {
                    statsCanvas.Opacity = 0;
                }
                else
                {
                    statsCanvas.Opacity = 0.6;
                }
            }
        }
    }
}

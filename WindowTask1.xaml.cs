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

namespace ComputerGraphics_03
{
    /// <summary>
    /// Логика взаимодействия для WindowTask1.xaml
    /// </summary>
    public partial class WindowTask1 : Window
    {

        private bool drawingLine = false;
        private bool fillingColour = false;
        private bool fillingImage = false;

        Point point = new Point();

        public WindowTask1()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ButtonDrawLine_Click(object sender, RoutedEventArgs e)
        {
            drawingLine = !drawingLine;
        }

        private void ButtonFillColor_Click(object sender, RoutedEventArgs e)
        {
            fillingColour = !fillingColour;
        }

        private void ButtonFillImage_Click(object sender, RoutedEventArgs e)
        {
            fillingImage = !fillingImage;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                point = e.GetPosition(this);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && drawingLine)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = point.X;
                line.Y1 = point.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                point = e.GetPosition(this);

                canvas.Children.Add(line);
            }
        }
    }
}

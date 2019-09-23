using Microsoft.Win32;
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

        private BitmapImage fillerImage = new BitmapImage();

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
            if (fillingImage) {
                for (int i = (int)point.X; i < 0; i++) {
                } 
            }
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

        private void ButtonSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fillerImage = new BitmapImage(new Uri(op.FileName));
                selectedImage.Source = fillerImage;
            }
        }
    }
}

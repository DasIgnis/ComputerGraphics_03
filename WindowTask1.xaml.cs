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
        WriteableBitmap wBitmap;

        public WindowTask1()
        {
            InitializeComponent();

            wBitmap = BitmapFactory.New(Convert.ToInt32(canvas.Width), Convert.ToInt32(canvas.Height));
            canvas.Source = wBitmap;

            wBitmap.Clear(Colors.White);
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
                point = e.GetPosition(canvas);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && drawingLine)
            {
                int x1 = Convert.ToInt32(point.X);
                int y1 = Convert.ToInt32(point.Y);

                int x2 = Convert.ToInt32(e.GetPosition(canvas).X);
                int y2 = Convert.ToInt32(e.GetPosition(canvas).Y);

                Console.WriteLine("Mouse X: " + x2 + " Mouse Y: " + y2);
                wBitmap.DrawLine(x1, y1, x2, y2, Color.FromRgb(0, 0, 0));



                point = e.GetPosition(canvas);
            }
        }
    }
}

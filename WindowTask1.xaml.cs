using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Bitmap imageGetter;

        System.Windows.Point point = new System.Windows.Point();
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
            fillingColour = false;
            fillingImage = false;
        }

        private void ButtonFillColor_Click(object sender, RoutedEventArgs e)
        {
            fillingColour = !fillingColour;
            fillingImage = false;
            drawingLine = false;
        }

        private void ButtonFillImage_Click(object sender, RoutedEventArgs e)
        {
            fillingImage = !fillingImage;
            fillingColour = false;
            drawingLine = false;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                point = e.GetPosition(canvas);
            if (e.ButtonState == MouseButtonState.Pressed && fillingImage && imageGetter != null)
            {
                System.Windows.Media.Color c = wBitmap.GetPixel(Convert.ToInt32(point.X), Convert.ToInt32(point.Y));
                fillWithImage(point, c);
            }
        }

        public void fillWithImage(System.Windows.Point point, System.Windows.Media.Color initialColor)
        {
            System.Windows.Point leftBorder = new System.Windows.Point(0, point.Y);
            System.Windows.Point rightBorder = new System.Windows.Point(canvas.Width, point.Y);
            for (int i = Convert.ToInt32(point.X); i >= 0; i--)
            {
                if (wBitmap.GetPixel(i, Convert.ToInt32(point.Y)).Equals(initialColor))
                {

                    System.Drawing.Color c = 
                        imageGetter.GetPixel(i % imageGetter.Width, Convert.ToInt32(point.Y) % imageGetter.Height);
                    wBitmap.SetPixel(i, Convert.ToInt32(point.Y), c.R, c.G, c.B);

                }
                else
                {
                    leftBorder = new System.Windows.Point(i, point.Y);
                    break;
                }
            }

            for (int i = Convert.ToInt32(point.X) + 1; i < canvas.Width; i++)
            {
                if (wBitmap.GetPixel(i, Convert.ToInt32(point.Y)).Equals(initialColor))
                {

                    System.Drawing.Color c =
                        imageGetter.GetPixel(i % imageGetter.Width, Convert.ToInt32(point.Y) % imageGetter.Height);
                    wBitmap.SetPixel(i, Convert.ToInt32(point.Y), c.R, c.G, c.B);

                }
                else
                {
                    rightBorder = new System.Windows.Point(i, point.Y);
                    break;
                }
            }

            for (int i = Convert.ToInt32(leftBorder.X + 1); i < Convert.ToInt32(rightBorder.X); i++)
            {
                if (wBitmap.GetPixel(i, Convert.ToInt32(point.Y) + 1).Equals(initialColor))
                {
                    fillWithImage(new System.Windows.Point(i, Convert.ToInt32(point.Y) + 1), initialColor);
                }
                if (wBitmap.GetPixel(i, Convert.ToInt32(point.Y) - 1).Equals(initialColor))
                {
                    fillWithImage(new System.Windows.Point(i, Convert.ToInt32(point.Y) - 1), initialColor);
                }
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && drawingLine)
            {
                int x1 = Convert.ToInt32(point.X);
                int y1 = Convert.ToInt32(point.Y);

                int x2 = Convert.ToInt32(e.GetPosition(canvas).X);
                int y2 = Convert.ToInt32(e.GetPosition(canvas).Y);

                wBitmap.DrawLine(x1, y1, x2, y2, System.Windows.Media.Color.FromRgb(0, 0, 0));



                point = e.GetPosition(canvas);
            }
        }

        private void ButtonSelectImage_Click(object sender, RoutedEventArgs e)
        {
            drawingLine = false;
            fillingColour = false;
            fillingImage = false;

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fillerImage = new BitmapImage(new Uri(op.FileName));
                selectedImage.Source = fillerImage;
                imageGetter = BitmapImage2Bitmap(fillerImage);
            }
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            wBitmap.Clear(Colors.White);
            drawingLine = false;
            fillingColour = false;
            fillingImage = false;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Windows.Interop;
using System.Drawing.Imaging;

namespace ComputerGraphics_03
{
    /// <summary>
    /// Логика взаимодействия для Task02.xaml
    /// </summary>
    public partial class Task02 : Window
    {
        enum CursorState
        {
            Idle,
            Process
        }

        private Bitmap original_bitmap;
        private CursorState cs;
        List<System.Drawing.Point> l;
        public Task02()
        {
            InitializeComponent();
            cs = CursorState.Idle;
            /* ( 1,  1) ( 0,  1) (-1,  1)
             * ( 1,  0) ( 0,  0) (-1,  0)
             * ( 1, -1) ( 0, -1) (-1, -1)
             */
            l = new List<System.Drawing.Point>();
            l.AddRange(new System.Drawing.Point[] { p(1, 1), p(1, 0), p(1, -1), p(0, -1), p(-1, -1), p(-1, 0), p(-1, 1), p(0, 1) });
        }

        private void load_image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                original_bitmap = new Bitmap(op.FileName);
                original_image.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void process_image(object sender, RoutedEventArgs e)
        {
            cs = CursorState.Process;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;
        }

        private void original_image_call(object sender, MouseButtonEventArgs e)
        {
            var btmp = original_bitmap;
            var t_point = e.GetPosition(original_image);
            var point = new System.Drawing.Point((int)(t_point.X * btmp.Width / original_image.ActualWidth), 
                (int)(t_point.Y * btmp.Height / original_image.ActualHeight));
            var color = get_pixel(point);
            while(true)
            {
                if(!point_in_image(point))
                {
                    point.X -= 1;
                    break;
                }
                if(get_pixel(point) != color)
                {
                    break;
                }
                point.X += 1;
            }
            var start_point = point;
            List<System.Drawing.Point> points = new List < System.Drawing.Point >();
            

            var current_point = start_point;
            var prew_point = p(start_point.X - 1, start_point.Y);
            var next_p = start_point;
            var prew_dir = p(1, 0);
            System.Drawing.Point next_dir;

            do
            {
                points.Add(current_point);
                next_p = next_point(prew_point, current_point, color, prew_dir, out next_dir);
                prew_point = current_point;
                current_point = next_p;
                prew_dir = p(current_point.X - prew_point.X, current_point.Y - prew_point.Y);

            } while (next_p != start_point);

            var opposite_color = System.Drawing.Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);

            foreach(var elem in points)
            {
                original_bitmap.SetPixel(elem.X, elem.Y, opposite_color);
            }

            original_image.Source = ToBitmapImage(original_bitmap);
        }

        private bool point_in_image(System.Drawing.Point p)
        {
            return 0 <= p.X && p.X < original_bitmap.Width && 0 <= p.Y && p.Y < original_bitmap.Height;
        }

        private System.Drawing.Point next_point(System.Drawing.Point prew_point, System.Drawing.Point current_point, 
            System.Drawing.Color color, System.Drawing.Point prew_direction, out System.Drawing.Point next_dir)
        {
            System.Drawing.Point last_point = prew_point;
            while (true)
            {
                next_dir = next_direction(prew_direction);

                System.Drawing.Point next_point = move_point(current_point, next_dir);

                if(next_point == prew_point)
                {
                    return prew_point;
                }

                if(!point_in_image(next_point))
                {
                    return last_point;
                }

                if (get_pixel(next_point) == color)
                {
                    prew_direction = next_dir;
                    last_point = next_point;
                    continue;
                }

                return next_point;
            }
        }

        private System.Drawing.Point move_point(System.Drawing.Point point, System.Drawing.Point direction)
        {
            return p(point.X - direction.X, point.Y - direction.Y);
        }

        private System.Drawing.Point next_direction(System.Drawing.Point prew_direction)
        {
            var ind = l.IndexOf(prew_direction);
            ind = (ind + 1) % l.Count();
            return l[ind];
        }

        private System.Drawing.Point p(int x, int y)
        {
            return new System.Drawing.Point(x, y);
        }

        private System.Drawing.Color get_pixel(System.Drawing.Point p)
        {
            return original_bitmap.GetPixel((int)p.X, (int)p.Y);
        }
        private BitmapImage ToBitmapImage(Bitmap bmp)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bmp.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
    }
}

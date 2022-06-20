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

namespace wpf8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cursor> cur = new List<Cursor>(29);
        BitmapImage[] ico = new BitmapImage[2];
        public MainWindow()
        {
            InitializeComponent();
            cur.Add(null);
            foreach (System.Reflection.PropertyInfo pi in
                typeof(Cursors).GetProperties())
                cur.Add((Cursor)pi.GetValue(null, null));
            button1.Tag = 0;

            for (int i = 1; i < 8; i++)
            {
                var rs = Application.GetResourceStream(new Uri("pack://application:,,,/C" + i + ".cur"));
                cur.Add(new Cursor(rs.Stream));
            }
            ico[0] = new BitmapImage(new Uri("pack://application:,,,/computer.ico"));
            ico[1] = new BitmapImage(new Uri("pack://application:,,,/Folder.ico"));
            Icon = ico[0];
            button5.Tag = 0;
           
        }
        
        private void button1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int k = (int)button1.Tag, c = cur.Count;
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    k = (k + 1) % c;
                    break;
                case MouseButton.Right:
                    k = (k - 1 + c) % c;
                    break;
            }
            button1.Content = k + ": " + (cur[k] == null ? "null" : cur[k].ToString());
            button1.Cursor = cur[k];
            button1.Tag = k;
            e.Handled = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Cursor = button1.Cursor;
            button2.Content = "this.Cursors=" +
                (Cursor == null ? "null" : Cursor.ToString());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ForceCursor = !ForceCursor;
            button3.Content = "this.ForceCursor=" + ForceCursor;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Mouse.OverrideCursor == null ?
                button1.Cursor : null;
            button4.Content = "Mouse.OverrideCursor=" + (Mouse.OverrideCursor == null ? "null" :
                Mouse.OverrideCursor.ToString());
            
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int k = ((int)button5.Tag + 1) % 2;
            button5.Content = "Icon " + k;
            button5.Tag = k;
            Icon = ico[k];
        }
        
    }
}

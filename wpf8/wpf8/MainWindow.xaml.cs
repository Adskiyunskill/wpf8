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
        public MainWindow()
        {
            InitializeComponent();
            cur.Add(null);
            foreach (System.Reflection.PropertyInfo pi in
                typeof(Cursors).GetProperties())
                cur.Add((Cursor)pi.GetValue(null, null));
            button1.Tag = 0;
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
    }
}

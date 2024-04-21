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

namespace CreatingTests
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TakeTheTest_Click(object sender, RoutedEventArgs e)
        {
            TakeTheTestWindow window = new TakeTheTestWindow();
            window.Show();
            Close();
        }

        private void ChangeTest_Click(object sender, RoutedEventArgs e)
        {
            TextAdmin.Visibility = Visibility.Visible;
            AdminWord.Visibility = Visibility.Visible;

            if (AdminWord.Text == "Admin")
            {
                TakeTheTestWindow window = new TakeTheTestWindow();
                window.TestEditor.IsEnabled = true;
                window.Show();
                Close();
            }
        }

    }
}
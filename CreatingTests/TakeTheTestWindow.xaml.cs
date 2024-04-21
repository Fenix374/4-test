using System;
using System.Collections.Generic;
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

namespace CreatingTests
{
    /// <summary>
    /// Логика взаимодействия для TakeTheTestWindow.xaml
    /// </summary>
    public partial class TakeTheTestWindow : Window
    {
        public TakeTheTestWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void StartTakingTheTest_Click(object sender, RoutedEventArgs e)
        {
            if (TestEditotTrue.Tests.Count == 1)
            {
                StartTakingFalse.Content = new Oops();
            }
            else
            {
                StartTakingFalse.Content = new StartTakingTrue();
            }

        }

        private void TestEditor_Click(object sender, RoutedEventArgs e)
        {
            StartTakingFalse.Content = new TestEditotTrue();
        }

        private void CreatingTest_loaded(object sender, RoutedEventArgs e)
        {
            DeSerializer serializer = new DeSerializer();
            TestEditotTrue.Tests = serializer.Deserialize<List<Test>>("tests.json");
        }

        private void WindowCreating_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TestEditotTrue.SaveTests();
        }
    }
}
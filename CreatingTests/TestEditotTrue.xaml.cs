using System.Collections.Generic;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using static CreatingTests.Test;
using System;
using System.Windows;

namespace CreatingTests
{
    /// <summary>
    /// Логика взаимодействия для TestEditotTrue.xaml
    /// </summary>
    public partial class TestEditotTrue : Page
    {
        public static Test first = new Test() { Name = "", Description = "", FirstAnswer = "", SecondAnswer = "", ThirdAnswer = "", RightAnswer = TestAnswer.First };
        static public List<Test> Tests = new List<Test>() { first };
        public TestEditotTrue()
        {
            InitializeComponent();
            LoadTests();
            DataGridTest.ItemsSource = Tests;
        }

        public static void SaveTests()
        {
            DeSerializer.Serialize(Tests, "tests.json");
        }

        private void LoadTests()
        {
            if (!File.Exists("tests.json"))
            {
                Tests = new List<Test> { first };
                SaveTests();
            }
        }

    }
}
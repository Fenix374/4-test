using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static CreatingTests.Test;

namespace CreatingTests
{
    /// <summary>
    /// Логика взаимодействия для StartTakingTrue.xaml
    /// </summary>
    public partial class StartTakingTrue : Page
    {
        public int indextest = 0;
        public bool AnswerCorrectORincorrect = true;
        public StartTakingTrue()
        {
            InitializeComponent();
            UpdateUI();
        }
        private void UpdateUI()
        {
            if (indextest < TestEditotTrue.Tests.Count)
            {
                Name.Text = TestEditotTrue.Tests[indextest].Name;
                Description.Text = TestEditotTrue.Tests[indextest].Description;
                RightORwrong.Text = "";
                ResetAnswerButtons();
            }
        }
        private void ResetAnswerButtons()
        {
            FirstAnswerButton.Content = TestEditotTrue.Tests[indextest].FirstAnswer;
            SecondAnswerButton.Content = TestEditotTrue.Tests[indextest].SecondAnswer;
            ThirdAnswerButton.Content = TestEditotTrue.Tests[indextest].ThirdAnswer;
        }
        private async void CheckAnswer(TestAnswer selectedAnswer)
        {
            if (indextest >= 0 && indextest < TestEditotTrue.Tests.Count)
            {
                if (selectedAnswer == TestEditotTrue.Tests[indextest].RightAnswer)
                {
                    RightORwrong.Text = "Correct answer :)";
                    await Task.Delay(1000);
                    AnswerCorrectORincorrect = true;
                }
                else
                {
                    RightORwrong.Text = "Incorrect answer :(";
                    await Task.Delay(1000);
                    AnswerCorrectORincorrect = false;
                }
                if (indextest < TestEditotTrue.Tests.Count - 1)
                {
                    indextest++;
                    UpdateUI();
                }
                else
                {
                    Name.Text = "";
                    Description.Text = "";
                    RightORwrong.Text = "All tests completed. Total answers: " + CountAnswers() + "   Number of correct answers: " + GetNumberOfCorrectAnswers();
                    FirstAnswerButton.Visibility = Visibility.Hidden;
                    SecondAnswerButton.Visibility = Visibility.Hidden;
                    ThirdAnswerButton.Visibility = Visibility.Hidden;
                }
            }
        }
        private int GetNumberOfCorrectAnswers()
        {
            int count = 0;
            for (int i = 0; i < TestEditotTrue.Tests.Count; i++)
            {
                if (TestEditotTrue.Tests[i].SelectedAnswer == TestEditotTrue.Tests[i].RightAnswer)
                {
                    count++;
                }
            }
            return count;
        }
        private int CountAnswers()
        {
            int count = 1;
            for (int i = 0; i < TestEditotTrue.Tests.Count; i++)
            {
                if (i < indextest)
                {
                    count++;
                }
            }
            return count;
        }
        private void FirstAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            TestEditotTrue.Tests[indextest].SelectedAnswer = TestAnswer.First;
            CheckAnswer(TestAnswer.First);
        }

        private void SecondAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            TestEditotTrue.Tests[indextest].SelectedAnswer = TestAnswer.Second;
            CheckAnswer(TestAnswer.Second);
        }

        private void ThirdAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            TestEditotTrue.Tests[indextest].SelectedAnswer = TestAnswer.Third;
            CheckAnswer(TestAnswer.Third);
        }
    }
}
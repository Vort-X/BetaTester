using PresentationLayer.Models;
using PresentationLayer.WpfApp.Commands;
using PresentationLayer.WpfApp.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace PresentationLayer.WpfApp.ViewModels
{
    public class TestViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private bool canAnswer;
        private bool canSave;
        private string correctiness = "";
        private QuestionDifficultyModel difficulty;
        private bool isNextEnabled = true;
        private string nextContent;
        private QuestionModel question;
        private string username;

        private readonly TestProcessor processor;

        public TestViewModel(TestProcessor processor)
        {
            this.processor = processor;

            AnswerCommand = new Command(p => 
            {
                int index = int.Parse(p as string);
                bool isCorrect = processor.GiveAnswer(index);
                Correctiness = isCorrect ? "Correct" : "INCORRECT";
                CanAnswer = false;
                IsNextEnabled = true;
            }, _ => CanAnswer);
            MenuCommand = new NavigationCommand(_ => { }, _ => true);
            NextCommand = new Command(_ =>
            {
                if (processor.HasNext())
                {   
                    processor.Next();
                }
                else
                {
                    processor.SaveAttempt(Username);
                    MenuCommand.Execute(_);
                }
            }, _ => IsNextEnabled);

            processor.QuestionUpdate += OnQuestionUpdate;
        }

        public bool CanAnswer
        {
            get => canAnswer;
            set => Update(ref canAnswer, value);
        }

        public string Correctiness
        {
            get => correctiness;
            set => Update(ref correctiness, value);
        }

        public QuestionDifficultyModel Difficulty
        {
            get => difficulty;
            set => Update(ref difficulty, value);
        }

        public bool IsNextEnabled
        {
            get => isNextEnabled;
            set => Update(ref isNextEnabled, value);
        }

        public string NextContent
        {
            get => nextContent;
            private set => Update(ref nextContent, value);
        }

        public QuestionModel Question
        {
            get => question;
            set => Update(ref question, value);
        }

        public string Username
        {
            get => username;
            set => Update(ref username, value);
        }

        public ICommand AnswerCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public void OnQuestionUpdate()
        {
            CanAnswer = true;
            canSave = !processor.HasNext();
            Correctiness = "";
            Difficulty = processor.CurrentDifficulty;
            IsNextEnabled = false;
            NextContent = processor.HasNext() ? "Next question" : "Finish test";
            Question = processor.CurrentQuestion;
        }
    }
}

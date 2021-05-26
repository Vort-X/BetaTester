using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class ConfigRowModel
    {
        public ConfigRowModel(QuestionDifficultyModel difficulty, int numberOfQuestions)
        {
            Difficulty = difficulty;
            NumberOfQuestions = numberOfQuestions;
        }

        public QuestionDifficultyModel Difficulty { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}

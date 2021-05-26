using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAttemptRepository AttemptRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuestionDifficultyRepository QuestionDifficultyRepository { get; }

        void Save();
    }
}

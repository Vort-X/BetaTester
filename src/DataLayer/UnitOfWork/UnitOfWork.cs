using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private readonly TesterContext dbContext;
        private IAttemptRepository attemptRepository;
        private IQuestionRepository questionRepository;
        private IQuestionDifficultyRepository questionDifficultyRepository;

        public UnitOfWork(TesterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IAttemptRepository AttemptRepository => attemptRepository ??= new AttemptRepository(dbContext);

        public IQuestionRepository QuestionRepository => questionRepository ??= new QuestionRepository(dbContext);

        public IQuestionDifficultyRepository QuestionDifficultyRepository => questionDifficultyRepository ??= new QuestionDifficultyRepository(dbContext);

        public void Dispose()   
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                dbContext.Dispose();
            }
            disposed = true;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}

using BusinessLogicLayer.Domain;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TesterContext dbContext;

        public QuestionRepository(TesterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Question GetById(int id)
        {
            return dbContext.Questions.Find(id).ToDomain();
        }

        public IEnumerable<Question> GetAll()
        {
            return dbContext.Questions.Select(q => q.ToDomain());
        }

        public void Add(Question domain)
        {
            var ent = domain.ToEntity();
            ent.NullifyReferences();
            dbContext.Questions.Add(ent);
            dbContext.SaveChanges();
        }

        public void Update(Question domain)
        {
            dbContext.Questions.Update(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public void Remove(Question domain)
        {
            dbContext.Questions.Remove(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public IEnumerable<Question> GetByDifficulty(QuestionDifficulty difficulty, int amount)
        {
            return dbContext.Questions
                .Where(q => q.Difficulty.Id == difficulty.Id)
                .OrderBy(q => Guid.NewGuid())
                .Take(amount)
                .Include(q => q.Difficulty)
                .Include(q => q.Answers)
                .Select(q => q.ToDomain());
        }
    }
}

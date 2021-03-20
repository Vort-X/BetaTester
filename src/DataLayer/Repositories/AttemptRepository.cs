using BusinessLogicLayer.Domain;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class AttemptRepository : IAttemptRepository
    {
        private readonly TesterContext dbContext;

        public AttemptRepository(TesterContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Attempt GetById(int id)
        {
            return dbContext.Attempts.Find(id).ToDomain();
        }

        public IEnumerable<Attempt> GetAll()
        {
            return dbContext.Attempts.Select(q => q.ToDomain());
        }

        public void Add(Attempt domain)
        {
            var ent = domain.ToEntity();
            ent.TestItems.ForEach(ti => ti.NullifyReferences());
            dbContext.Attempts.Add(ent);
            dbContext.SaveChanges();
        }

        public void Update(Attempt domain)
        {
            dbContext.Attempts.Update(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public void Remove(Attempt domain)
        {
            dbContext.Attempts.Remove(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public IEnumerable<Attempt> GetLeaders(int amount)
        {
            return dbContext.Attempts
                .OrderByDescending(a => a.TestItems.Select(ti => ti.Question.Difficulty.Points).Sum())
                .ThenByDescending(a => a.TestItems.Where(ti => ti.GotRightAnswer).Select(ti => ti.Question.Difficulty.Points).Sum())
                .Take(amount)
                .Include(a => a.TestItems)
                .ThenInclude(ti => ti.Question.Difficulty)
                .Include(a => a.TestItems)
                .ThenInclude(ti => ti.Question.Answers)
                .Select(a => a.ToDomain());
        }
    }
}

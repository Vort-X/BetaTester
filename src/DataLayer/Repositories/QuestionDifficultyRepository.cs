using BusinessLogicLayer.Domain;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class QuestionDifficultyRepository : IQuestionDifficultyRepository
    {
        private readonly TesterContext dbContext;

        public QuestionDifficultyRepository(TesterContext dbContext)
        {
            this.dbContext = dbContext;
            
            //Удалить эту гадость
            if (!GetAll().Any())
            {
                Add(new QuestionDifficulty(0, "Easy", 1));
                Add(new QuestionDifficulty(0, "Normal", 3));
                Add(new QuestionDifficulty(0, "Hard", 6));
            }
        }

        public QuestionDifficulty GetById(int id)
        {
            return dbContext.QuestionDifficulties.Find(id).ToDomain();
        }

        public IEnumerable<QuestionDifficulty> GetAll()
        {
            return dbContext.QuestionDifficulties.Select(qd => qd.ToDomain());
        }

        public void Add(QuestionDifficulty domain)
        {
            dbContext.QuestionDifficulties.Add(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public void Remove(QuestionDifficulty domain)
        {
            dbContext.QuestionDifficulties.Remove(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public void Update(QuestionDifficulty domain)
        {
            dbContext.QuestionDifficulties.Update(domain.ToEntity());
            dbContext.SaveChanges();
        }

        public TestConfig CreateConfig()
        {
            var cfg = new TestConfig();
            GetAll().ToList().ForEach(qd => cfg.QuestionsOfEachDifficulty[qd] = 0);
            return cfg;
        }

        //Удалить эту гадость
        private static QuestionDifficultyRepository instance;
        public static QuestionDifficultyRepository Init()
        {
            if (instance is null)
            {
                instance = new QuestionDifficultyRepository(TesterContext.Init());
            }
            return instance;
        }
    }
}

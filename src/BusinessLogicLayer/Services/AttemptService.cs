using BusinessLogicLayer.Domain;
using BusinessLogicLayer.Interfaces;
using DataLayer.Interfaces;
using Mappers;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class AttemptService : IAttemptService
    {
        protected readonly IAttemptRepository attemptRepository;

        public AttemptService(IAttemptRepository attemptRepository)
        {
            this.attemptRepository = attemptRepository;
        }

        public List<AttemptInfo> GetTopTen()
        {
            return attemptRepository
                .GetLeaders(10)
                .Select(a => new AttemptInfo(a.TesterName, a.TestingDate, attemptRepository.GetPoints(a.Id)))
                .ToList();
        }

        public void SaveAttempt(Attempt attempt)
        {
            attemptRepository.Add(attempt.ToEntity());
        }
    }
}

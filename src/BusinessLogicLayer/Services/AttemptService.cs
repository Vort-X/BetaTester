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

        public List<Attempt> GetTopTen()
        {
            return attemptRepository.GetLeaders(10).Select(a => a.ToDomain()).ToList();
        }

        public void SaveAttempt(Attempt attempt)
        {
            attemptRepository.Add(attempt.ToEntity());
        }
    }
}

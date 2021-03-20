using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mappers;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using PresentationLayer.Models;
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

        public List<AttemptModel> GetTopTen()
        {
            return attemptRepository.GetLeaders(10).Select(a => a.ToModel()).ToList();
        }

        public void SaveAttempt(AttemptModel attempt)
        {
            attemptRepository.Add(attempt.ToDomain());
        }
    }
}

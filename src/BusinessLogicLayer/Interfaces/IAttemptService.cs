using PresentationLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAttemptService
    {
        List<AttemptModel> GetTopTen();
        void SaveAttempt(AttemptModel attempt);
    }
}

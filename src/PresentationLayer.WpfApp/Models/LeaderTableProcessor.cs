using BusinessLogicLayer.Interfaces;
using Mappers;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.WpfApp.Models
{
    public class LeaderTableProcessor
    {
        private readonly IAttemptService attemptService;

        public LeaderTableProcessor(IAttemptService attemptService)
        {
            this.attemptService = attemptService;
        }

        public IEnumerable<AttemptInfoModel> GetLeaderTable()
        {
            return attemptService.GetTopTen().Select(a => a.ToModel());
        }
    }
}

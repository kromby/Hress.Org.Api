﻿using Ez.Hress.Hardhead.Entities;
using Microsoft.Extensions.Logging;

namespace Ez.Hress.Hardhead.UseCases
{
    public class AwardInteractor
    {
        private IAwardDataAccess _awardDataAccess;
        private ILogger<AwardInteractor> _log;

        public AwardInteractor(IAwardDataAccess dataAccess, ILogger<AwardInteractor> log)
        {
            _awardDataAccess = dataAccess;
            _log = log;
        }

        public void Nominate(Nomination nomination)
        {
            if (nomination == null)
                throw new ArgumentNullException(nameof(nomination));            

            nomination.Validate();
            nomination.CreatedDate = DateTime.Now;

            _log.LogInformation($"Nominating {nomination.NomineeID} in group {nomination.TypeID} for {nomination.Description} by {nomination.CreatedBy}");

            _awardDataAccess.SaveNomination(nomination);
        }
    }
}
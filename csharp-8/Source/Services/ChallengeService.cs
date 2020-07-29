using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return (from challenge in _context.Challenges
                    join acceleration in _context.Accelerations
                        on challenge.Id equals acceleration.ChallengeId
                    join candidate in _context.Candidates
                       on acceleration.Id equals candidate.AccelerationId
                    where candidate.UserId == userId && acceleration.Id==accelerationId
                    select challenge)
                         .Distinct()
                         .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            var challengeInDatabase = _context.Challenges
                                                  .FirstOrDefault(c => c.Id == challenge.Id);

            bool forCreate = challengeInDatabase == null;

            Models.Challenge savedChallenge;
            if (forCreate)
            {
                savedChallenge = (_context.Challenges.Add(challenge)).Entity;
            }
            else
            {
                challengeInDatabase.Name = challenge.Name ?? challenge.Name;
                challengeInDatabase.Slug = challenge.Slug ?? challenge.Slug;

                savedChallenge = (_context.Challenges.Update(challengeInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedChallenge;
        }
    }
}
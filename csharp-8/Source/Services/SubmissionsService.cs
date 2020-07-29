using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return (from submission in _context.Submissions
                    join challenge in _context.Challenges
                       on submission.ChallengeId equals challengeId
                    join acceleration in _context.Accelerations
                       on accelerationId equals acceleration.Id
                    select submission)
                         .Distinct()
                         .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                    .Where(s => s.ChallengeId == challengeId)
                    .Select(s => s.Score)
                    .Max();
        }

        public Submission Save(Submission submission)
        {
            if (submission.ChallengeId == 0 ||
                submission.UserId == 0)
            {
                return null;
            }

            var submissionInDatabase = _context.Submissions
                                                  .FirstOrDefault(s => s.UserId == submission.UserId &&
                                                  s.ChallengeId == submission.ChallengeId);

            bool forCreate = submissionInDatabase == null;

            Submission savedSubmission;
            if (forCreate)
            {
                savedSubmission = (_context.Submissions.Add(submission)).Entity;
            }
            else
            {
                submissionInDatabase.Score = submission.Score;

                savedSubmission = (_context.Submissions.Update(submissionInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedSubmission;
        }
    }
}

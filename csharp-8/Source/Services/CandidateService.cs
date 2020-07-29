using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                    .Where(u => u.AccelerationId == accelerationId)
                    .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                    .Where(u => u.CompanyId == companyId)
                    .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates
                    .Where(
                            u => u.UserId == userId &&
                            u.AccelerationId == accelerationId &&
                            u.CompanyId == companyId
                           )
                    .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            if (candidate.AccelerationId == 0 ||
                candidate.CompanyId == 0 ||
                candidate.UserId == 0)
            {
                return null;
            }

            var candidateInDatabase = _context.Candidates
                                                  .FirstOrDefault(c => c.UserId == candidate.UserId && 
                                                  c.AccelerationId == candidate.AccelerationId &&
                                                  c.CompanyId == candidate.CompanyId);

            bool forCreate = candidateInDatabase == null;

            Candidate savedCandidate;
            if (forCreate)
            {
                savedCandidate = (_context.Candidates.Add(candidate)).Entity;
            }
            else
            {
                candidateInDatabase.Status = candidate.Status;

                savedCandidate = (_context.Candidates.Update(candidateInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedCandidate;
        }
    }
}

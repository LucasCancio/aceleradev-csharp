using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return (from acceleration in _context.Accelerations
                    join candidate in _context.Candidates
                       on acceleration.Id equals candidate.AccelerationId
                    where candidate.CompanyId == companyId
                    select acceleration)
                         .Distinct()
                         .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations
                    .Where(a => a.Id == id)
                    .FirstOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            var accelerationInDatabase = _context.Accelerations
                                                  .FirstOrDefault(a => a.Id == acceleration.Id);

            bool forCreate = accelerationInDatabase == null;

            Acceleration savedAcceleration;
            if (forCreate)
            {
                savedAcceleration = (_context.Accelerations.Add(acceleration)).Entity;
            }
            else
            {
                accelerationInDatabase.Name = acceleration.Name ?? acceleration.Name;
                accelerationInDatabase.Slug = acceleration.Slug ?? acceleration.Slug;
                accelerationInDatabase.ChallengeId = acceleration.ChallengeId==0?
                                                    accelerationInDatabase.ChallengeId : 
                                                    acceleration.ChallengeId;

                savedAcceleration = (_context.Accelerations.Update(accelerationInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedAcceleration;
        }
    }
}

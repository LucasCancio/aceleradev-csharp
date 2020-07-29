using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return (from candidate in _context.Candidates
                    join company in _context.Companies 
                        on candidate.CompanyId equals company.Id
                    where candidate.AccelerationId == accelerationId
                    select company
                )
                .Distinct()
                .ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
        }

        public IList<Company> FindByUserId(int userId)
        {
            return (from candidate in _context.Candidates
                    join company in _context.Companies 
                        on candidate.CompanyId equals company.Id
                    where candidate.UserId == userId
                    select company)
                    .Distinct()
                    .ToList();
        }

        public Company Save(Company company)
        {
            var companyInDatabase = _context.Companies
                                                  .FirstOrDefault(c => c.Id == company.Id);

            bool forCreate = companyInDatabase == null;

            Company savedCompany;
            if (forCreate)
            {
                savedCompany = (_context.Companies.Add(company)).Entity;
            }
            else
            {
                companyInDatabase.Name = company.Name ?? company.Name;
                companyInDatabase.Slug = company.Slug ?? company.Slug;

                savedCompany = (_context.Companies.Update(companyInDatabase)).Entity;
            }
            _context.SaveChanges();

            return savedCompany;
        }
    }
}
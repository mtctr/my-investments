using DividendMap.Web.Domain.Entities;
using DividendMap.Web.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DividendMap.Web.Data.Adapters
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DividendsContext _context;

        public CompanyRepository(DividendsContext context)
        {
            _context = context;
        }

        public async Task Add(Company company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }

        public async Task<Company> FirstOrDefault(Expression<Func<Company, bool>> predicate)
        {            
            return await _context.Companies.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task Remove(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Company company)
        {
            _context.Update(company);
            await _context.SaveChangesAsync();
        }
    }
}

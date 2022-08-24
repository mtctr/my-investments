using DividendMap.Web.Domain.Entities;
using System.Linq.Expressions;

namespace DividendMap.Web.Domain.Ports
{
    public interface ICompanyRepository
    {
        Task Add(Company company);
        Task Update(Company company);
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetById(int id);
        Task<Company> FirstOrDefault(Expression<Func<Company, bool>> predicate);
        Task Remove(Company company);
        bool Exists(int id);
    }
}

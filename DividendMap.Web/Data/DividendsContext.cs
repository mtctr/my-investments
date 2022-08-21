using DividendMap.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DividendMap.Web.Data;

public class DividendsContext : DbContext
{
    public DividendsContext(DbContextOptions<DividendsContext> options) :base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Dividend> Dividends { get; set; }
    public DbSet<DividendMap.Web.Models.CompanyViewModel>? CompanyViewModel { get; set; }
}

using DividendMap.Web.Domain.Entities;

namespace DividendMap.Web.Models
{
    public class DividendViewModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime ExDate { get; set; }
        public DateTime PayDate { get; set; }
        public int CompanyId { get; set; }
        public DividendType Type { get; set; }
    }
}

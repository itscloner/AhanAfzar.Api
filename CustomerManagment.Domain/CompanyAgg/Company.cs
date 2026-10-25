
using _0_Framework.Domain;

namespace CustomerManagment.Domain.CompanyAgg
{
    public class Company : EntityBase<long>
    {
        public string Name { get; set; }
        public string? BrandName { get; set; } // نام تجاری
        public string? NationalId { get; set; } // شناسه ملی
        public string? EconomicCode { get; set; } // کد اقتصادی
        public string Description { get; set; }

        public Company(string name, string? brandName, string? nationalId, string? economicCode, string description)
        {
            Name = name;
            BrandName = brandName;
            NationalId = nationalId;
            EconomicCode = economicCode;
            Description = description;
        }

        public void Edit(string name, string? brandName, string? nationalId, string? economicCode, string description)
        {
            Name = name;
            BrandName = brandName;
            NationalId = nationalId;
            EconomicCode = economicCode;
            Description = description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WEBA_EF_CaseStudy1.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        //Defining a property with a ? symbol after the DateTime datatype,
        //to tell the .NET engine's Entity Framework that, this is a Nullable property.
    }
}


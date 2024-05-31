using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class Customer
    { 
        public int CustomerId { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }

    }
}

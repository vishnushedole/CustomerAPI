using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class CreateCustomer
    {
        public int EnquiryId { get; set; }
        public int EmpId { get; set; }
    }
}

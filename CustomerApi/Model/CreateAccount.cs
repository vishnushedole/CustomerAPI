using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class CreateAccount
    {
        public int BranchId { get; set; }
        public int CustId { get; set; }
        public int AccType { get; set; }
        public decimal InitialBalance { get; set; }
        

    }
}

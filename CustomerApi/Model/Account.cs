using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class Account
    {
        public int AccId { get; set; }
        public int CustId {  get; set; }
        public int BranchId { get; set; }
        public int NoOfFreeWithdrawal {  get; set; }
        public int NoOfFreeDepoit { get; set; }
        public int AccountType {  get; set; }
        public decimal Balance { get; set; }
        public int IsActive { get; set; }
        public int IsCheckBook { get; set; }
    }
}

using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class CreateCustomerResponse
    {
        public string? UserId { get; set; }
        public string? Password { get; set;}
    }
}

using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IFSC { get; set; }

    }
}

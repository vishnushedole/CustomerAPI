using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Model
{
    [ExcludeFromCodeCoverage]
    public class Enquirer
    {
        public int EnquiryId { get; set; }  
            public string? Email { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Addr { get; set; }
            public string? PanNo { get; set; }
            public string? AadhaarNo { get; set; }
            public string? PhoneNo { get; set; }
            public string? City { get; set; }
            public string? Stat { get; set; }
            public string? Country { get; set; }
            public string? PinCode { get; set; }
            public string? MaritalStatus { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string? GuardianName { get; set; }
            public string? GuardianAccount { get; set; }
            public string? GuardianPhoneNo { get; set; }
            public string? GuardianEmail { get; set; }
            
            public string? GuardianAadhaar { get; set; }
            public int isActive { get; set; }
            public decimal InitialBalance { get; set; }
            public int AccountType { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class DocModel
    {
        public int DocId { get; set; }
        public int EnqId { get; set; }
        public int CustId { get; set; }
        public string DocType { get; set; }
        public bool IsApproved { get; set; }
        public IFormFile? DocFile { get; set; }
    }


    [ExcludeFromCodeCoverage]
    public class DocWithImageData
    {
        public DocModel DocModel { get; set; }
        public string ImageData { get; set; }
    }
}

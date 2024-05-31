using CustomerApi.Model;
using CustomerApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class CustomerController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<Enquirer> GetById(int id)
        {
            CustomerRepository rp  = new CustomerRepository();
            return rp.GetCustomerById(id);
        }

        [HttpPost("update")]
        public ActionResult<Enquirer> Update([FromBody] Enquirer enquirer)
        {

            CustomerRepository rp = new CustomerRepository();
            Enquirer enq = rp.GetCustomerById(enquirer.EnquiryId);

            if (enq is not null)
            {
                enq.EnquiryId = enquirer.EnquiryId;
                enq.Email = enquirer.Email;
                enq.FirstName = enquirer.FirstName;
                enq.LastName = enquirer.LastName;
                enq.Addr = enquirer.Addr;
                enq.PanNo = enquirer.PanNo;
                enq.AadhaarNo = enquirer.AadhaarNo;
                enq.PhoneNo = enquirer.PhoneNo;
                enq.City = enquirer.City;
                enq.Stat = enquirer.Stat;
                enq.Country = enquirer.Country;
                enq.PinCode = enquirer.PinCode;
                enq.MaritalStatus = enquirer.MaritalStatus;
                enq.Gender = enquirer.Gender;
                enq.Age = enquirer.Age;
                enq.GuardianName = enquirer.GuardianName;
                enq.GuardianAccount = enquirer.GuardianAccount;
                enq.GuardianPhoneNo = enquirer.GuardianPhoneNo;
                enq.GuardianEmail = enquirer.GuardianEmail;
                enq.GuardianAadhaar = enquirer.GuardianAadhaar;
                enq.isActive = enquirer.isActive;
                enq.InitialBalance = enquirer.InitialBalance;
                enq.AccountType = enquirer.AccountType;
                return rp.UpdateCustomer(enq);
            }
            return enq!;
        }

        [HttpPost("CreateCustomer")]
        public ActionResult<CreateCustomerResponse> CreateCustomer(CreateCustomer custDetails)
        {
            CustomerRepository rp = new CustomerRepository();
            return rp.CreateCustomer(custDetails.EnquiryId, custDetails.EmpId);    
        }
        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(CreateAccount accDetails)
        {
            Console.WriteLine(accDetails);
            CustomerRepository rp = new CustomerRepository();
            if (rp.CreateAccount(accDetails.BranchId, accDetails.CustId, accDetails.AccType, accDetails.InitialBalance))
                return Ok();
            else return BadRequest();
        }
       
        [HttpGet("GetAllAccounts")]
        public ActionResult<List<Account>> GetAllAccounts(int CustId)
        {
            CustomerRepository rp = new CustomerRepository();
            return rp.GetAllAccounts(CustId);
        }

        [HttpGet("CheckEnquiry")]
        public ActionResult<bool> CheckEnquiry(int EnqId,string email)
        {
            CustomerRepository rp = new CustomerRepository();
            return rp.CheckEnquiry(EnqId, email);
        }

        [HttpGet("BranchList")]
        public ActionResult<List<string>> BranchList()
        {
            CustomerRepository rp = new CustomerRepository();
            return rp.BranchList();
        }
        [HttpGet("GetDocumentIds/{id}")]
        public ActionResult<List<int>> GetDocumentIds(int id)
        {
            CustomerRepository rp = new CustomerRepository();
            return rp.GetDocumentIds(id);
        }
        [HttpGet("getDocWithImage/{docId}")]
        public IActionResult GetDocWithImage(int docId)
        {
            CustomerRepository rp = new CustomerRepository();
            var docWithImageData = rp.GetDocWithImageData(docId);

            if (docWithImageData == null)
                return NotFound();

            return Ok(docWithImageData);
        }
       
    }
}

using CustomerApi.Model;
using CustomerApi.Repository;

namespace CustomerTesting
{
    [TestClass]
    public class UnitTest1
    {
        CustomerRepository rp = new CustomerRepository();

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            var CustId = 2;
            var result = rp.GetCustomerById(CustId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Harsh");
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Enquirer e = new Enquirer();


            e.EnquiryId = 5;
            e.Email = "harsh1717gupta@gmail.com";
            e.FirstName = "Harsh";
            e.LastName = "Gupta";
            e.Addr = "harsh3101gupta@gmail.com";
            e.PanNo = "dsgsfgsdfs";
            e.AadhaarNo = "sdfsdfsdfsdf";
            e.PhoneNo = "0725489311";
            e.City = "sdfsfsdfsdf";
            e.Stat = "sdfsdfsff";
            e.Country = "India";
            e.PinCode = "12345";
            e.MaritalStatus = "xccv";
            e.Gender = "M";
            e.Age = 18;
            e.GuardianName = "sdfsg";
            e.GuardianAccount = "sdfvdf";
            e.GuardianPhoneNo = "sdfvdf";
            e.GuardianEmail = "harsh1717gupta@outlook.com";
            e.GuardianAadhaar = "sdfsfvaefsdf";
            e.isActive = 0;
            e.InitialBalance = 11111111;
            e.AccountType = 1;

        
            var result = rp.UpdateCustomer(e);
            Assert.IsNotNull(result);
            var result1 = rp.GetCustomerById(2);
            Assert.AreEqual(result.PinCode, result1.PinCode);
        }
        [TestMethod]
        public void CreateCustomerTest()
        {
            var EmpId = 1;
            var EnqId = 38;
            var result = rp.CreateCustomer(EnqId, EmpId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.UserId, "VishnuTest3325");
            Assert.AreEqual(result.Password, "Password25");
        }
        [TestMethod]
        public void CreateAccountTest()
        {
            var branchId = 1;
            var Acctype = 1;
            var initialBalance = 10000;
            var custId = 2;
            var count1 = rp.GetAllAccounts(custId).Count();
            var result = rp.CreateAccount(branchId,custId,Acctype,initialBalance);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, true);
            var count2 = rp.GetAllAccounts(custId).Count();
            Assert.AreEqual(count1+1, count2);
        }
        [TestMethod]
        public void GetAllAccountsTest()
        {
            var custId = 2;
            var count = 3;
            var count1 = rp.GetAllAccounts(custId).Count();
            Assert.IsNotNull(count1);
            Assert.AreEqual(count1, count);
        }
        [TestMethod]
        public void CheckEnquiryTest()
        {
            var EnqId = 36;
            var Email = "vishnushedole09@gmail.com";
            var result = rp.CheckEnquiry(EnqId, Email);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, false);
        }
        [TestMethod]
        public void BranchListTest()
        {
            var result = rp.BranchList().Count();
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void GetDocumentIdsTest()
        {
            var custId = 5;
            var result = rp.GetDocumentIds(custId).Count();
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void GetDocWithImageDataTest()
        {
            var docId = 47;
            var result = rp.GetDocWithImageData(docId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.DocModel.EnqId, 16);
            Assert.AreEqual(result.DocModel.CustId, 19);
            Assert.AreEqual(result.DocModel.DocType, "Test");
        }
    }
}
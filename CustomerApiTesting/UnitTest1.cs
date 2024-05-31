using CustomerApi.Repository;

namespace CustomerApiTesting
{
    [TestClass]
    public class UnitTest1
    {
        CustomerRepository rp = new CustomerRepository();

        [TestMethod]
        public void GetCustomerByIdTest()
        {
            var CustId = 1;
            var result  = rp.GetCustomerById(CustId);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, "Harsh");
        }
    }
}
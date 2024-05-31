using CustomerApi.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CustomerApi.Repository
{
    public class CustomerRepository : BaseDataAccess
    {
        public Enquirer GetCustomerById(int id)
        {
            string sql = "sp_GetCustomerDetails";
            Enquirer enquirer = new Enquirer();
            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                    parameters: new SqlParameter("@CustId", id));
                while (reader.Read())
                {
                    enquirer.EnquiryId = reader.GetInt32(0);
                    enquirer.InitialBalance = reader.GetDecimal(1);
                    enquirer.Email = reader.GetString(2);
                    enquirer.FirstName = reader.GetString(3);
                    enquirer.LastName = reader.GetString(4);
                    enquirer.Addr = reader.GetString(5);
                    enquirer.PanNo = reader.GetString(6);
                    enquirer.AadhaarNo = reader.GetString(7);
                    enquirer.PhoneNo = reader.GetString(8);
                    enquirer.City = reader.GetString(9);
                    enquirer.Stat = reader.GetString(10);
                    enquirer.Country = reader.GetString(11);
                    enquirer.PinCode = reader.GetString(12);
                    enquirer.MaritalStatus = reader.GetString(13);
                    enquirer.Gender = reader.GetString(14);
                    enquirer.Age = reader.GetInt32(15);
                    enquirer.AccountType = reader.GetInt32(16);
                    enquirer.GuardianName = reader.GetString(17);
                    enquirer.GuardianAccount = reader.GetString(18);
                    enquirer.GuardianPhoneNo = reader.GetString(19);
                    enquirer.GuardianEmail = reader.GetString(20);

                    enquirer.GuardianAadhaar = reader.GetString(21);
                    enquirer.isActive = reader.GetInt32(22);



                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return enquirer;
        }
        public Enquirer UpdateCustomer(Enquirer enquirer)
        {
            Console.WriteLine("Hello");
            string sql = "sp_UpdateCustomerDetails";

            try
            {
                ExecuteNonQuery(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                  new SqlParameter("@EnquiryId", enquirer.EnquiryId),
                  new SqlParameter("@Email", enquirer.Email),
                  new SqlParameter("@FirstName", enquirer.FirstName),
                  new SqlParameter("@LastName", enquirer.LastName),
                  new SqlParameter("@Addr", enquirer.Addr),
                new SqlParameter("@PanNo", enquirer.PanNo),
                new SqlParameter("@AadhaarNo", enquirer.AadhaarNo),
                new SqlParameter("@PhoneNo", enquirer.PhoneNo),
                new SqlParameter("@City", enquirer.City),
                new SqlParameter("@Stat", enquirer.Stat),
                new SqlParameter("@Country", enquirer.Country),
                new SqlParameter("@PinCode", enquirer.PinCode),
                new SqlParameter("@MaritalStatus", enquirer.MaritalStatus),
                new SqlParameter("@Gender", enquirer.Gender),
                new SqlParameter("@Age", enquirer.Age),
                new SqlParameter("@GuardianName", enquirer.GuardianName),
                new SqlParameter("@GuardianAccount", enquirer.GuardianAccount),
                new SqlParameter("@GuardianPhoneNo", enquirer.GuardianPhoneNo),
                new SqlParameter("@GuardianEmail", enquirer.GuardianEmail),
                new SqlParameter("@GuardianAadhaar", enquirer.GuardianAadhaar),
                new SqlParameter("@isActive", enquirer.isActive),
                new SqlParameter("@InitialBalance", enquirer.InitialBalance),
                new SqlParameter("@AccountType", enquirer.AccountType));
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return enquirer;
        }
        public CreateCustomerResponse CreateCustomer(int enquiryId, int empId)
        {
            string sql = "sp_CreateCustomer";
            CreateCustomerResponse customerRes = new CreateCustomerResponse();
            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                  new SqlParameter("@enqId", enquiryId),
                  new SqlParameter("@empId", empId),
                 new SqlParameter("@return", SqlDbType.Int) { Direction = ParameterDirection.Output }
                  );
                while (reader.Read())
                {
                    customerRes.UserId = reader.GetString(0);
                    customerRes.Password = reader.GetString(1);
                }
                if (!reader.IsClosed) reader.Close();

            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return customerRes;
        }
        public bool CreateAccount(int branchId, int custId, int accType, decimal InitialBalance)
        {
            string sql = "sp_CreateAccount";
            bool flag = false;
            try
            {

                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                  new SqlParameter("@branchid", branchId),
                  new SqlParameter("@custid", custId),
                  new SqlParameter("@acctype", accType),
                 new SqlParameter("@initial_balance", InitialBalance)
                  );
                while (reader.Read())
                {
                    flag = reader.GetBoolean(0);
                }

                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public List<Account> GetAllAccounts(int CustId)
        {
            string sql = "sp_ListAccount";
            List<Account> accounts = new List<Account>();
            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                    parameters: new SqlParameter("@CustId", CustId));
                while (reader.Read())
                {
                    Account acc = new Account();

                    acc.AccId = reader.GetInt32(0);

                    acc.CustId = reader.GetInt32(1);
                    acc.BranchId = reader.GetInt32(2);
                    acc.Balance = reader.GetDecimal(3);
                    acc.NoOfFreeWithdrawal = reader.GetInt32(4);
                    acc.NoOfFreeDepoit = reader.GetInt32(5);
                    acc.AccountType = reader.GetInt32(6);
                    acc.IsActive = reader.GetInt32(7);
                    acc.IsCheckBook = reader.GetInt32(8);
                    accounts.Add(acc);
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return accounts;
        }

        public bool CheckEnquiry(int enqId, string email)
        {
            string sql = "sp_CheckEnquirer";
            bool response = false;
            List<Account> accounts = new List<Account>();
            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                     new SqlParameter("@EnquiryId", enqId),
                     new SqlParameter("@Email", email));
                while (reader.Read())
                {
                    int EId = reader.GetInt32(0);
                    if (EId > 0)
                        response = true;
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return response;
        }
        public List<string> BranchList()
        {
            string sql = "sp_BranchList";
            List<string> branches = new List<string>();

            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure
                    );
                while (reader.Read())
                {
                    branches.Add(reader.GetString(1));

                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return branches;
        }
        public List<int> GetDocumentIds(int id)
        {
            string sql = "sp_getDocumentidbyCustId";
            List<int> documentIds = new List<int>();

            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                    new SqlParameter("@CustId", id)
                    );
                while (reader.Read())
                {
                    documentIds.Add(reader.GetInt32(0));

                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return documentIds;
        }

        public DocWithImageData GetDocWithImageData(int docId)
        {
            string sql = "sp_GetDocWithImageDataForCustomer";


            try
            {
                var reader = ExecuteSql(
                    sqltext: sql,
                    commandType: CommandType.StoredProcedure,
                    new SqlParameter("@DocId", docId)
                    );
                while (reader.Read())
                {
                    var docModel = new DocModel
                    {
                        DocId = (int)reader["DocId"],
                        EnqId = (int)reader["EnqId"],
                        CustId = (int)reader["CustId"],
                        DocType = reader["DocType"].ToString(),
                        IsApproved = (bool)reader["IsApproved"]
                    };
                    var imageData = (byte[])reader["Doc"];
                    var base64Image = Convert.ToBase64String(imageData);
                    return new DocWithImageData { DocModel = docModel, ImageData = "data:image/jpeg;base64," + base64Image };

                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }
        
    }
}

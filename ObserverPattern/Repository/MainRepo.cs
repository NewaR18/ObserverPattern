using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;
using ObserverPattern.Models;

namespace ObserverPattern.Repository
{
    public class MainRepo:ConnRepo
    {
        private readonly InfinityDbContext _context;
        public MainRepo(InfinityDbContext context) {
            _context = context;
        }
        public List<CustomerMast> RegisterUser()
        {
            IQueryable<CustomerMast> listCustomers = _context.CustomerMasts.Where(st => st.BirthDate.Value.Month == DateTime.Now.Month);
            return listCustomers.ToList();
        }
        public void InsertInSMSLog(CustomerMast customerData)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into SMS_LOG(BR_CODE,SMS_SERVICE_TYPE_CODE,MOBILE_NO,MESSAGE_TEXT,SMS_DATE) VALUES ('001',10,@mobileNo,@message,GETDATE())";
                using (SqlConnection conn = Connection())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@mobileNo", SqlDbType.VarChar).Value = customerData.MobileNo;
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = "The DOB/Name was Updated";
                    int outputResult= cmd.ExecuteNonQuery();  
                    if(outputResult > 0) { 
                        Console.WriteLine("Inserted In SMS LOG");
                    }
                }
            }
        }
    }
}

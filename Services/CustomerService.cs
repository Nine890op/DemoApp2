using Dapper;
using customer.Data;
using MudBlazor.Charts;
using Npgsql;
using DemoApp2.Data;

namespace DemoApp2.Services
{
    public interface ICustomerService
    {
        List<customer> GetAllCustomer();
    }
    public class CustomerService : ICustomerService
    {
        public List<customer> GetAllCustomer()
        {
            List<customer> Res = new List<customer>();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(GbVer.ConnectionString))
                {
                    con.Open();
                    string SQL = "select * from customer order by name1";
                    Res = con.Query<customer>(SQL).ToList();
                }
            }
            catch (Exception ex)
            { }
            return Res;
        }
    }
}
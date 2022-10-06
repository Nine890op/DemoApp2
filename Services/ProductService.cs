using Dapper;
using Npgsql;
using DemoApp2.Data;

namespace DemoApp2.Services
{
    public interface IProductService
    {
        List<product> GetAllProduct();
    }
    public class ProductService : IProductService
    {
        public List<product> GetAllProduct()
        {
            List<product> Res = new List<product>();
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(GbVer.ConnectionString))
                {
                    con.Open();
                    string SQL = "select * from product order by name1";
                    Res = con.Query<product>(SQL).ToList();
                }
            }
            catch (Exception ex)
            { }
            return Res;
        }
    }
}
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAL
{
    public class DB
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Server=.;Database=QuanLyQuanCafe;Trusted_Connection=True;"
            );
        }
    }
}
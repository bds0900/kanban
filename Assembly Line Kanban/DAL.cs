using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Line_Kanban
{
    public class DAL
    {
        public DAL()
        {

        }
        public int GetPassed()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(TestTrayID) from Trays where Teststatus=1", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int GetTotal()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(TestTrayID) from Trays where Teststatus is not null", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int GetInProcess()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(TestTrayID) from Trays where Teststatus is null", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int GetOrderAmount()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select ConfigValue from Configuration where ConfigID='OrderAmount'", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration_Tool
{
    public class DAL
    {
        DataTable dt;
        SqlDataAdapter adapter;
        const string GetKeyValueQuery= "select ConfigID, ConfigValue from Configuration;";
        const string ScaleUpQuery = "update EmployeeSkill set Speed = Speed / 2;update Configuration set ConfigValue=ConfigValue/2 where ConfigID='RunInterval' ";
        const string ScaleDownQuery = "update EmployeeSkill set Speed = Speed * 2;update Configuration set ConfigValue=ConfigValue*2 where ConfigID='RunInterval'";

        public DAL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    dt = new DataTable();
                }
                
            }
            catch (SqlException ex)
            {
                throw new DALException("Please check your query and database");
            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
        }
        public DataTable GetConfiguration()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    using(SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand(GetKeyValueQuery, conn);
                        adapter.Fill(dt);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection");
            }
            return dt;
        }
        public void SaveConfiguration(DataTable dataTable)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand(GetKeyValueQuery, conn);
                        SqlCommandBuilder cb = new SqlCommandBuilder(adapter);
                        adapter.UpdateCommand = cb.GetUpdateCommand();
                        adapter.Update(dataTable);
                    }

                }
                
            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection");
            }

        }

        public void SetStations()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    //run configuration
                    SqlCommand cmd = new SqlCommand("Configure", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@StationID", ID));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new DALException("open the connection first...");
            }
            catch (SqlException ex)
            {
                throw new DALException("Hmm...I think your configuration ID or Value is invalid...");
            }

        }

        public void ScaleUP()
        {
            using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ScaleUpQuery, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void ScaleDown()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ScaleDownQuery, conn);
                cmd.ExecuteNonQuery();

            }
        }

    }
}

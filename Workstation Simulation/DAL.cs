using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workstation_Simulation
{
    public class DAL
    {
        DataTable dt;
        SqlDataAdapter adapter;
        const string GetKeyValueQuery = "select ConfigID, ConfigValue from Configuration;";
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


        public DataTable GetEmplyeeType()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        const string GetEmployeeQeury = "select Type from EmployeeSkill";
                        conn.Open();
                        adapter.SelectCommand = new SqlCommand(GetEmployeeQeury, conn);
                        adapter.Fill(dt);

                    }

                }

            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
            return dt;

        }
        public DataTable GetStation()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {

                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        const string GetDeactivatedStationQuery = "select StationID from Station where Active=0";
                        adapter.SelectCommand = new SqlCommand(GetDeactivatedStationQuery, conn);
                        adapter.Fill(dt);

                    }
                }
            }

            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
            return dt;

        }

        public DataTable GetActivatedStation()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {

                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        const string GetDeactivatedStationQuery = "select StationID from Station where Active=1";
                        adapter.SelectCommand = new SqlCommand(GetDeactivatedStationQuery, conn);
                        adapter.Fill(dt);

                    }
                }
            }

            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
            return dt;

        }

        public void Hire(string type)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Hire", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@type", type));
                    cmd.ExecuteNonQuery();

                }

            }
            catch (SqlException)
            {
                throw new DALException("Please select type");
            }

            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }

        }

        public DataTable GetEmlployeeList()
        {
            DataTable emplyoee = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        const string GetDeactivatedEmployeeQeury = "select EmployeeID,Type from Employee where Active=0;";
                        adapter.SelectCommand = new SqlCommand(GetDeactivatedEmployeeQeury, conn);
                        adapter.Fill(emplyoee);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
            return emplyoee;
        }

        public int GetInterval(int stationID)
        {

            //SqlDataReader rdr = null;
            int retVal = 0;
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select dbo.WorkSpeeds(@StationID)", conn);
                    cmd.Parameters.Add(new SqlParameter("@StationID", stationID));

                    retVal = Convert.ToInt32(Convert.ToDouble(cmd.ExecuteScalar()) * 1000);
                }
            }
            catch (Exception ex)
            {
                throw new DALException("Please check your connection string");
            }
            return retVal;
        }

        public void Activate(string stationID, string employeeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {

                    conn.Open();
                    //run the work station
                    SqlCommand cmd = new SqlCommand("Activate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StationID", stationID));
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                throw new DALException("Please check your query and database");
            }
        }


        public void Work(string stationID, string employeeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"select StationID from Station where StationID={stationID}", conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        //run the work station
                        cmd = new SqlCommand("WorkStation", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@StationID", stationID));
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DALException("Please check your query and database");
            }

        }



        public void Deactivate(string stationID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    //run the work station
                    SqlCommand cmd = new SqlCommand("Deactivate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StationID", stationID));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DALException("Please check your query and database");
            }

        }
    }
}

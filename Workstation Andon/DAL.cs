using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workstation_Andon
{
    public class DAL
    {
        public DAL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                }

            }
            catch (InvalidOperationException ex)
            {
                throw new DALException("Fail to create command builder");
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


        public DataTable GetTable(string StationID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        string query = $"select Parts.Name,Bin.Quantities,Parts.Capacity from Bin inner join StationBin on StationBin.BinID=Bin.BinID inner join Parts on Parts.PartID = Bin.PartID where StationBin.StationID = {StationID};";
                        adapter.SelectCommand = new SqlCommand(query, conn);
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

        public DataTable GetStationList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        string query = "select StationID from Station;";
                        adapter.SelectCommand = new SqlCommand(query, conn);
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
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Working_Simulation
{
    public partial class Runner : Form
    {
        int time;
        public Runner()
        {
            InitializeComponent();
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Runner", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                Run.Start();
                Timer.Start();
            }
        }

        private void Run_Tick(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Configuration"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select ConfigValue from Configuration where ConfigID='RunInterval'", conn);
                var interval = Convert.ToInt32(cmd.ExecuteScalar());
                cmd = new SqlCommand("Runner", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                Run.Interval = interval * 1000;

                
                Timer.Interval = 1000;
                time = interval;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Time.Text = time.ToString();
            time--;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Run.Stop();
            Timer.Stop();
        }
    }
}

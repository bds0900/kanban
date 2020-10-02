using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workstation_Simulation
{
    public partial class Simulation : Form
    {
        DAL dataAccess;
        public string Employee { get; set; }
        public string EmployeeID { get; set; }
        public string StationID { get; set; }
        public Simulation()
        {
            InitializeComponent();

            AddBtn.Enabled = false;
            RefreshBtn.Enabled = false;
            ActivateBtn.Enabled = false;
            DeactivateBtn.Enabled = false;
        }
        private void ConnBtn_Click(object sender, EventArgs e)
        {
            dataAccess = new DAL();
            DataTable dt = new DataTable();
            //clear the employee list
            EmployeeComboBox.Items.Clear();
            //clear the station list
            AssemblyLines.Items.Clear();
            try
            {
                //get employee type
                dt = dataAccess.GetEmplyeeType();
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeComboBox.Items.Add(row[0].ToString());
                }
                dt.Clear();

                //get line id and fill the combobox
                dt = dataAccess.GetStation();
                foreach (DataRow row in dt.Rows)
                {
                    AssemblyLines.Items.Add(row[0].ToString());
                }
                dt.Clear();


                MessageBox.Show("Connection success");
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Refresh();

            ConnBtn.Enabled = false;
            AddBtn.Enabled = true;
            RefreshBtn.Enabled = true;

            ActivateBtn.Enabled = true;
            DeactivateBtn.Enabled = true;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            EmployeeList.Items.Clear();
            try
            {
                dataAccess.Hire(EmployeeComboBox.Text);
                dt = dataAccess.GetEmlployeeList();
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeList.Items.Add(row[0].ToString() + ":" + row[1].ToString());
                }
                dt.Clear();
            }

            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please check your connection string");
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Refresh();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Refresh()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = dataAccess.GetStation();
                AssemblyLines.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    AssemblyLines.Items.Add(row[0].ToString());
                }
                dt.Clear();

                EmployeeList.Items.Clear();
                dt = dataAccess.GetEmlployeeList();
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeList.Items.Add(row[0].ToString() + ":" + row[1].ToString());
                }
                dt.Clear();

                ActivatedLines.Items.Clear();
                dt = dataAccess.GetActivatedStation();
                foreach (DataRow row in dt.Rows)
                {
                    ActivatedLines.Items.Add(row[0].ToString());
                }
                dt.Clear();

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }

        }

        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            string parse = EmployeeList.Text;
            string[] employeeID = parse.Split(':');
            EmployeeID = employeeID[0];
            StationID = AssemblyLines.Text;
            //check if the access and strings are emtpy

            try
            {
                if (dataAccess != null && StationID != "" && EmployeeID != "")
                {
                    dataAccess.Activate(StationID, EmployeeID);
                }

                WorkSpeed.Start();
                Refresh();
                MessageBox.Show(StationID + " is activated");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }
        }

        private void DeactivateBtn_Click(object sender, EventArgs e)
        {
            string stationID = ActivatedLines.Text;

            try
            {
                dataAccess.Deactivate(stationID);
                WorkSpeed.Stop();
                Refresh();
                MessageBox.Show(StationID + " is deactivated");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }
        }

        private void EmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee = EmployeeComboBox.Text;
        }

        private void WorkSpeed_Tick(object sender, EventArgs e)
        {
            try
            {
                dataAccess.Work(StationID, EmployeeID);
                WorkSpeed.Interval = dataAccess.GetInterval(Convert.ToInt32(StationID));
            }
            catch (DALException ex)
            {
                WorkSpeed.Stop();
                MessageBox.Show(ex.Message);
            }
        }
    }
}

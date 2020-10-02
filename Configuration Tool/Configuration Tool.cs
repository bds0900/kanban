using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuration_Tool
{
    public partial class Configuration : Form
    {
        DataTable gridTable;
        DAL dataAccess;
        public Configuration()
        {
            InitializeComponent();
            gridTable = new DataTable();
            LoadBtn.Enabled = false;
            SaveBtn.Enabled = false;
            SetBtn.Enabled = false;
            UpBtn.Enabled = false;
            DownBtn.Enabled = false;

        }

        private void ConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataAccess = new DAL();
                MessageBox.Show("Connection success");
                LoadBtn.Enabled = true;
                SaveBtn.Enabled = true;
                SetBtn.Enabled = true;
                ConnBtn.Enabled = false;
                UpBtn.Enabled = true;
                DownBtn.Enabled = true;

            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                gridTable.Clear();
                gridTable = dataAccess.GetConfiguration();
                GridView.DataSource = gridTable;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            GridView.Refresh();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataAccess.SaveConfiguration((DataTable)GridView.DataSource);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
            GridView.Refresh();
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataAccess.SetStations();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please connect first");
            }
        }
    }
}

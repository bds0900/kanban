using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workstation_Andon
{
    public partial class Andon : Form
    {
        DAL dataAccess;
        public Andon()
        {
            InitializeComponent();
        }
        private void ConnBtn_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dataAccess = new DAL();
            dt = dataAccess.GetStationList();

            foreach (DataRow row in dt.Rows)
            {
                LineList.Items.Add(row[0]);
            }
        }

        private void LineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Updater.Start();
        }

       
        private void Updater_Tick(object sender, EventArgs e)
        {
            DataTable dt;
            dt = dataAccess.GetTable(LineList.Text);

            foreach (DataRow row in dt.Rows)
            {
                if (row["Name"].ToString() == "Harness")
                {
                    CalProgress(Harness, HarnessPer,row);
                }
                else if (row["Name"].ToString() == "Reflector")
                {
                    CalProgress(Reflector, ReflectorPer, row);
                }
                else if (row["Name"].ToString() == "Housing")
                {
                    CalProgress(Housing, HousingPer, row);
                }
                else if (row["Name"].ToString() == "Lens")
                {
                    CalProgress(Lens, LensPer, row);
                }
                else if (row["Name"].ToString() == "Bulb")
                {
                    CalProgress(Bulb, BulbPer, row);
                }
                else if (row["Name"].ToString() == "Bezel")
                {
                    CalProgress(Bezel, BezelPer, row);
                }

            }
        }
        private void CalProgress(ProgressBar progresBar, Label label, DataRow row)
        {
            double percent = 0;
            progresBar.Maximum = Convert.ToInt32(row["Capacity"]);
            if (Convert.ToInt32(row["Quantities"]) > progresBar.Maximum)
            {
                progresBar.Value = progresBar.Maximum;
            }
            else
            {
                progresBar.Value = Convert.ToInt32(row["Quantities"]);
            }
            percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
            label.Text = percent.ToString("F") + "%";
            if (percent < 10)
            {
                progresBar.ForeColor = Color.Red;
            }
            else if (percent < 30)
            {
                progresBar.ForeColor = Color.Yellow;
            }
            else
            {
                progresBar.ForeColor = Color.Green;
            }
        }

    }
}

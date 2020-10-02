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
            double percent = 0;


            foreach (DataRow row in dt.Rows)
            {
                if (row["Name"].ToString() == "Harness")
                {
                    Harness.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Harness.Maximum)
                    {
                        Harness.Value = Harness.Maximum;
                    }
                    else
                    {
                        Harness.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    HarnessPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Harness.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Harness.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Harness.ForeColor = Color.Green;
                    }
                }
                else if (row["Name"].ToString() == "Reflector")
                {
                    Reflector.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Reflector.Maximum)
                    {
                        Reflector.Value = Reflector.Maximum;
                    }
                    else
                    {
                        Reflector.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    ReflectorPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Reflector.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Reflector.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Reflector.ForeColor = Color.Green;
                    }
                }
                else if (row["Name"].ToString() == "Housing")
                {
                    Housing.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Housing.Maximum)
                    {
                        Housing.Value = Housing.Maximum;
                    }
                    else
                    {
                        Housing.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    HousingPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Housing.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Housing.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Housing.ForeColor = Color.Green;
                    }
                }
                else if (row["Name"].ToString() == "Lens")
                {
                    Lens.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Lens.Maximum)
                    {
                        Lens.Value = Lens.Maximum;
                    }
                    else
                    {
                        Lens.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    LensPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Lens.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Lens.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Lens.ForeColor = Color.Green;
                    }
                }
                else if (row["Name"].ToString() == "Bulb")
                {
                    Bulb.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Bulb.Maximum)
                    {
                        Bulb.Value = Bulb.Maximum;
                    }
                    else
                    {
                        Bulb.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    BulbPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Bulb.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Bulb.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Bulb.ForeColor = Color.Green;
                    }
                }
                else if (row["Name"].ToString() == "Bezel")
                {
                    Bezel.Maximum = Convert.ToInt32(row["Capacity"]);
                    if (Convert.ToInt32(row["Quantities"]) > Bezel.Maximum)
                    {
                        Bezel.Value = Bezel.Maximum;
                    }
                    else
                    {
                        Bezel.Value = Convert.ToInt32(row["Quantities"]);
                    }
                    percent = Convert.ToDouble(row["Quantities"]) / Convert.ToDouble(row["Capacity"]) * 100;
                    BezelPer.Text = percent.ToString("F") + "%";
                    if (percent < 10)
                    {
                        Bezel.ForeColor = Color.Red;
                    }
                    else if (percent < 30)
                    {
                        Bezel.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        Bezel.ForeColor = Color.Green;
                    }
                }

            }
        }

    }
}

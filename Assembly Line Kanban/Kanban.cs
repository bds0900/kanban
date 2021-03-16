using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assembly_Line_Kanban
{
    public partial class Kanban : Form
    {
        DAL dataAccess;
        public Kanban()
        {
            InitializeComponent();
        }

        private void ConnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataAccess = new DAL();
                MessageBox.Show("Connection success");
                Updater.Start();
            }
            catch (DALException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            float orderAmount = dataAccess.GetOrderAmount();
            float passed = dataAccess.GetPassed();
            float inProcess = dataAccess.GetInProcess();
            float total = dataAccess.GetTotal();

            float yield = total!=0?(passed / total) * 100 : 0;

            OrderAmount.Text = orderAmount.ToString();
            Passed.Text = passed.ToString();
            InProcess.Text = inProcess.ToString();
            Yield.Text = yield.ToString("F") + "%";
            Total.Text = total.ToString();
        }
    }
}

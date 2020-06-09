using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MySql.Data.MySqlClient;

namespace dengue
{
    public partial class add_dengue : Form
    {
        MySqlConnection connect = new MySqlConnection(dengue.Properties.Resources.connect.ToString());
        public MySqlCommand cmd;

        private void add()
        {
            connect.Open();
            string sql = "INSERT into cases(birthdate, case_date_in, case_date_out, subdistrict) VALUES(@birthdate, @case_date_in, @case_date_out, @subdistrict)";
            using(MySqlCommand cmd  = new MySqlCommand(sql,connect))
            {
                cmd.Parameters.Add("@birthdate", MySqlDbType.Date).Value=birthdateTxt.Value.Date;
                cmd.Parameters.Add("@case_date_in", MySqlDbType.Date).Value=admissionTxt.Value.Date;
                cmd.Parameters.Add("@case_date_out", MySqlDbType.Date).Value = dischargedTxt.Value.Date;
                cmd.Parameters.Add("@subdistrict",MySqlDbType.VarChar,30).Value=subdistrictTxt.selectedValue;
                cmd.ExecuteNonQuery();
            }
            connect.Close();
        }

        public add_dengue()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            add();
            MessageBox.Show("Added Successfully");
        }

        private void homemenu_Click(object sender, EventArgs e)
        {
            var home = new home_dengue();
            home.Show();
            this.Hide();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            var newadd = new add_dengue();
            newadd.Show();
            this.Hide();
        }

        private void readmenu_Click(object sender, EventArgs e)
        {
            var read = new read_dengue();
            read.Show();
            this.Hide();
        }

        private void updatemenu_Click(object sender, EventArgs e)
        {
            var update = new update_dengue();
            update.Show();
            this.Hide();
        }

        private void deletemenu_Click(object sender, EventArgs e)
        {
            var delete = new delete_dengue();
            delete.Show();
            this.Hide();
        }
    }
}

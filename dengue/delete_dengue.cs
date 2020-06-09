using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MySql.Data.MySqlClient;

namespace dengue
{
    public partial class delete_dengue : Form
    {
        MySqlConnection connect = new MySqlConnection(dengue.Properties.Resources.connect.ToString());
        public MySqlCommand cmd;

        private void delete()
        {
            connect.Open();
            string sql = "DELETE from cases WHERE id=@id";
            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(caseID.Text);
                cmd.ExecuteNonQuery();
            }
            connect.Close();
        } 
        public delete_dengue()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            delete();
            MessageBox.Show("Deleted Successfully");
        }

        private void homemenu_Click(object sender, EventArgs e)
        {
            var home = new home_dengue();
            home.Show();
            this.Hide();
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            var add = new add_dengue();
            add.Show();
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
            var newdelete = new delete_dengue();
            newdelete.Show();
            this.Hide();
        }
    }
}

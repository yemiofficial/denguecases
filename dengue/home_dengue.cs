using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dengue
{
    public partial class home_dengue : Form
    {
        public home_dengue()
        {
            InitializeComponent();
        }

        private void homemenu_Click(object sender, EventArgs e)
        {
            var newhome = new home_dengue();
            newhome.Show();
            this.Hide();
        }
        private void addmenu_Click(object sender, EventArgs e)
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
            var delete = new delete_dengue();
            delete.Show();
            this.Hide();
        }
    }
}

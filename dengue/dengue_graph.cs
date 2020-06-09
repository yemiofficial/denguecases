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
using Bunifu.DataViz;

namespace dengue
{
    public partial class dengue_graph : Form
    {
        MySqlConnection connect = new MySqlConnection(dengue.Properties.Resources.connect.ToString());
        public MySqlCommand cmd;

        public dengue_graph()
        {
            InitializeComponent();
        }

        private void linegraph()
        {
            var canvas = new Bunifu.DataViz.Canvas();
            var DataPoint1 = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_spline);
            var DataPoint2 = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_spline);
            var DataPoint3 = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_spline);
            var DataPoint4 = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_spline);

            connect.Open();
            string sql = "Select count(*) from cases where subdistrict=@subdistrict and Year(case_date_in)=@year";

            var subs = new List<string>() { "Andir", "Antapani", "Arcamanik", "Astanaanyar", "Babakan Ciparay", "Bandung Kidul", "Bandung Kulon", "Bandung Wetan", "Batununggal", "Bojongloa Kaler", "Bojongloa Kidul", "Buah Batu", "Cibeunying Kaler", "Cibeunying Kidul", "Cibiru", "Cicendo", "Cidadap", "Cinambo", "Coblong", "Gedebage", "Kiaracondong", "Lengkong", "Mandalajati", "Panyileukan", "Rancasari", "Regol", "Sukajadi", "Sukasari", "Sumurbandung", "Ujung Berung" };
            var years = new List<int>() { 2014, 2015, 2016, 2017 };

            using (MySqlCommand cmd = new MySqlCommand(sql, connect))
            {
                foreach (int year in years)
                {
                    foreach (string sub in subs)
                    {
                        cmd.Parameters.Add(new MySqlParameter("@subdistrict", MySqlDbType.VarChar, 30) { Value = sub });
                        cmd.Parameters.Add(new MySqlParameter("@year", MySqlDbType.Int32) { Value = year });

                        int data = Convert.ToInt32(cmd.ExecuteScalar());

                        if (year == 2014)
                        {
                            DataPoint1.addLabely(sub, data.ToString());
                        }
                        else if (year == 2015)
                        {
                            DataPoint2.addLabely(sub, data.ToString());
                        }
                        else if (year == 2016)
                        {
                            DataPoint3.addLabely(sub, data.ToString());
                        }
                        else
                        {
                            DataPoint4.addLabely(sub, data.ToString());
                        }
                        cmd.Parameters.Clear();
                    }
                }
            canvas.addData(DataPoint1);
            canvas.addData(DataPoint2);
            canvas.addData(DataPoint3);
            canvas.addData(DataPoint4);
            }
            bunifuDataViz2.Render(canvas);
            connect.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            linegraph();
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

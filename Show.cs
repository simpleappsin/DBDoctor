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

namespace DBDoctor
{
    public partial class Show : Form
    {

        SqlCommand komut;
        SqlConnection baglanti;
        SqlDataAdapter da;

        public Show()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti = new SqlConnection("server=" + TxtServer.Text + ";Initial Catalog=" + TxtDatabaseName.Text + ";Integrated Security=SSPI");
                baglanti.Open();
                da = new SqlDataAdapter("SELECT * FROM " + TxtTableName.Text, baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                baglanti.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtDatabaseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TxtServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=" + TxtServer.Text + ";Integrated Security=True");

                connection.Open();
                SqlCommand command = new SqlCommand("Select * from sys.databases", connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                }
                connection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

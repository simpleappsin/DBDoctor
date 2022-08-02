using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string server_name;

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Database Back Up";
            saveFileDialog1.Filter = "Back Up Files BAK(*bak)|*.bak | Back Up Files TM(*tm)|*.tm | Back Up Files LOG(*log)|*.log | All Files(*.*)|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TxtFilePath.Text = saveFileDialog1.FileName;
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtDatabaseName.Text != "" && TxtFilePath.Text != "" && TxtServer.Text != "")
                {
                    Server dbServer = new Server(new ServerConnection(TxtServer.Text));
                    Backup dbBackup = new Backup();
                    dbBackup.Action = BackupActionType.Database; // Bunun bir Database dosyasi oldugunu belirtiyoruz!
                    dbBackup.Database = TxtDatabaseName.Text; //Database'nin adini ayarliyoruz!
                    dbBackup.Devices.AddDevice(TxtFilePath.Text, DeviceType.File);
                    dbBackup.Initialize = false;
                    dbBackup.SqlBackup(dbServer);
                    dbBackup.Complete += DbBackup_Complete1;
                }
                else if (TxtDatabaseName.Text != "" && TxtFilePath.Text != "" && TxtServer.Text != "" && TxtUsername.Text != "" && TxtPassword.Text != "")
                {
                    Server dbServer = new Server(new ServerConnection(TxtServer.Text, TxtUsername.Text, TxtPassword.Text));
                    Backup dbBackup = new Backup();
                    dbBackup.Action = BackupActionType.Database; // Bunun bir Database dosyasi oldugunu belirtiyoruz!
                    dbBackup.Database = TxtDatabaseName.Text; //Database'nin adini ayarliyoruz!
                    dbBackup.Devices.AddDevice(TxtFilePath.Text, DeviceType.File);
                    dbBackup.Initialize = false;
                    dbBackup.SqlBackup(dbServer);
                    dbBackup.Complete += DbBackup_Complete;
                }
                else
                {
                    MessageBox.Show("Please fill all required boxes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Error: " + es.Message);
            }
        }

        private void DbBackup_Complete1(object sender, ServerMessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Completed succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Completed succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCnI2fV_2-pvYrwjI7KFW0pA");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            bunifuTileButton3.BackColor = Color.FromArgb(32, 35, 55);
            List list = new List();
            list.ShowDialog();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            bunifuTileButton4.BackColor = Color.FromArgb(32, 35, 55);
            Show show = new Show();
            show.ShowDialog();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            bunifuTileButton2.BackColor = Color.FromArgb(32, 35, 55);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timee.Text = DateTime.Now.ToString("hh:mm:ss");
            dayy.Text = DateTime.Now.ToString("dddd, MM/dd/yyyy");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4_proga
{
    public partial class Form1 : Form
    {
        private Client client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.client = new Client(maskedTextBox1.Text, int.Parse(maskedTextBox2.Text));
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listBox1.Items.Add(drive.Name);
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(drives[0].Name);
            DirectoryInfo[] dirs = directoryInfo.GetDirectories();
            foreach(DirectoryInfo dir in dirs)
            {
                listBox2.Items.Add(dir.Name);
            }
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] answers = this.client.Request(listBox2.SelectedItem.ToString()).Split('#');
                foreach (string answer in answers)
                {
                    listBox3.Items.Add(answer);
                }
            }
            catch
            {
                MessageBox.Show("Каталог не доступен.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.client.stream.Close();
            this.client.topClient.Close();
            this.Close();
        }
    }
}

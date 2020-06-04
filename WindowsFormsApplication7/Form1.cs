using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Data", con);
            cmd.CommandType = CommandType.Text;
            string date=""; 

            SqlDataReader reader = cmd.ExecuteReader();
            string name = textBox1.Text;
            DateTime now = DateTime.Now;

            while (reader.Read())
            {
                if (name == reader["user_name"].ToString())
                {
                    
                    date = reader["Date"].ToString();
                    DateTime oDate = Convert.ToDateTime(date);
                    Form2 f = new Form2();
                    f.Show();
                    TimeSpan t = now-oDate;
                    int x = (int)t.TotalDays;

                    MessageBox.Show(string.Format("You have {0} Dayes Left !!",(14-x).ToString()),"License");

                }
                else
                {
                    MessageBox.Show("This user dose not exist !!");


                    

                }
            }
        }
    }
}

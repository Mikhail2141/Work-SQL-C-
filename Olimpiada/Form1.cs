using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // функция подключения к бд 
        void StringCoonection()
        {
            string StringConnection = "Server=localhost;Database=jak;Trusted_Connection=True";
            string command = "SELECT *  FROM Sport";

            using (SqlConnection sqlConnection = new SqlConnection(StringConnection))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView1.DataSource = dataTable;
            }

        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringCoonection();
        }
    }
}

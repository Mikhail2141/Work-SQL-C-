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

namespace Olimpiada
{
    public partial class Form6 : Form
    {
        Form1 form1 = new Form1 ();
        public Form6(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void MEDAL()
        {

            string command = "SELECT Name, total\r\nFROM Countries\r\nORDER BY total DESC\r\n "; 


            using (SqlConnection sqlConnection = new SqlConnection(form1.StringConnection))
            {
                sqlConnection.Open();

                 
                try
                {
                     
                    SqlCommand cmd = new SqlCommand(command, sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable currentDataTable = new DataTable();
                    currentDataTable.Load(reader);
                    dataGridView1.DataSource = currentDataTable;





                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            MEDAL();



        }
    }
}

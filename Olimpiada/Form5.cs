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
   
    public partial class Form5 : Form
    {
        Form1 form1 = new Form1();
        public Form5(Form1 form1)
        {
            this.form1 =  form1;

            InitializeComponent();
        }



        public void getDataBase()
        {
            List<string> list = new List<string>()
            {
                "select Data, Season, City, Host FROM Olimpiada",

                 "select Name FROM Sport" ,

                 "select FIO, Data, Country FROM Sportsmens" 


            };

            using (SqlConnection sqlConnection = new SqlConnection(form1.StringConnection))
            {
                sqlConnection.Open();

                DataTable combinedDataTable = new DataTable(); // Новый DataTable для объединения результатов

                try
                {
                    for (int i = 0; i < list.Count; ++i)
                    {
                        SqlCommand cmd = new SqlCommand(list[i], sqlConnection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable currentDataTable = new DataTable();
                        currentDataTable.Load(reader);

                        // Объединяем данные из текущего DataTable с общим DataTable
                        combinedDataTable.Merge(currentDataTable);
                    }

                    // Устанавливаем объединённый DataTable как источник данных для DataGridView
                    dataGridView1.DataSource = combinedDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        

        private void button1_Click(object sender, EventArgs e)
        {
            getDataBase();
        }
    }
}

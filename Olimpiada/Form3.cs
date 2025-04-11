using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada
{
    public partial class Form3 : Form
    {

        class TableDefinition
        {
            public string TableName { get; set; }
            public List<string> ColumnNames { get; set; }

            public TableDefinition(string tableName, params string[] columnNames)
            {
                TableName = tableName;
                ColumnNames = columnNames.ToList();
            }
        }


        private Dictionary<int, Control[]> textBoxesByOption = new Dictionary<int, Control[]>();
       private List<Label> labels = new List<Label>();
        private ListBox listBox;
        Form1 form = new Form1();

        public Form3(Form1 form1)
        {
            InitializeComponent();
            InitializeComponents();
            this.form = form1;
        }

        private void InitializeComponents()
        {
            listBox = new ListBox
            {
                Location = new Point(10, 10),
                Size = new Size(200, 120)
            };

            listBox.Items.AddRange(new object[]
            {
                "Добавить в таблицу спортсмены",
                "Добавить в таблицу олимпиада",
                "Добавить в таблицу спорт",
                "Добавить в таблицу страны"
            });

            listBox.SelectedIndexChanged += OnSelectedIndexChanged;
            Controls.Add(listBox);

            CreateDefaultTextBoxes();
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = listBox.SelectedIndex;

            RemoveExistingControls();

            switch (selectedIndex)
            {
                case 0:
                    GenerateFormForTable(new TableDefinition("Sportsmens", "FIO", "Data", "Country"));
                    break;
                case 1:
                    GenerateFormForTable(new TableDefinition("Olimpiada", "Data", "Season", "City", "Host"));
                    break;
                case 2:
                    GenerateFormForTable(new TableDefinition("Sport", "Name"));
                    break;
                case 3:
                    GenerateFormForTable(new TableDefinition("Countries", "Name", "gold", "silver", "bronze", "total"));
                    break;
            }
        }

        private void RemoveExistingControls()
        {
            foreach (var controls in textBoxesByOption.Values)
            {
                foreach (var item in labels)
                {
                    foreach (var control in controls)
                    {
                        Controls.Remove(control);
                        Controls.Remove(item); 
                    }
                }
                
            }
            textBoxesByOption.Clear();
            labels.Clear();
            
        }

        private void CreateDefaultTextBoxes()
        {
            // Логика для создания стандартных текстовых полей при загрузке формы
        }

        private void GenerateFormForTable(TableDefinition tableDef)
        {
            textBoxesByOption.Clear();

            List<TextBox> textBoxes = new List<TextBox>();
            

            for (int i = 0; i < tableDef.ColumnNames.Count; ++i)
            {
                int yPosition = 50 + i * 30;

                labels.Add(new Label
                {
                    Text = tableDef.ColumnNames[i],
                    Location = new Point(250, yPosition),
                    AutoSize = true
                });

                textBoxes.Add(new TextBox
                {
                    Name = "txt" + tableDef.ColumnNames[i].Replace(" ", ""),
                    Location = new Point(350, yPosition),
                    Size = new Size(100, 20)
                });
            }

            Button addButton = new Button
            {
                Text = "Добавить",
                Location = new Point(350, 250),
                Size = new Size(100, 100)
            };

            addButton.Click += (sender, args) =>
            {
                string[] values = textBoxes.Select(tb => tb.Text).ToArray();
                InsertIntoTable(tableDef, values);
            };

            foreach (var label in labels)
            {
                Controls.Add(label);
            }

            foreach (var textBox in textBoxes)
            {
                Controls.Add(textBox);
            }

            Controls.Add(addButton);

            textBoxesByOption[listBox.SelectedIndex] = textBoxes.Concat(new Control[] { addButton }).ToArray();
        }

        private void InsertIntoTable(TableDefinition tableDef, string[] values)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(form.StringConnection))
                {
                    connection.Open();

                    string columns = string.Join(", ", tableDef.ColumnNames);
                    string parameters = string.Join(", ", tableDef.ColumnNames.Select((col, i) => "@param" + i));

                    string query = $"INSERT INTO {tableDef.TableName} ({columns}) VALUES ({parameters});";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        for (int i = 0; i < tableDef.ColumnNames.Count; ++i)
                        {
                            command.Parameters.AddWithValue("@param" + i, values[i]);
                            
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно добавлены.");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении данных.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
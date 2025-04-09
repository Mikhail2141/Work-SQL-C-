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
            InitializingСomponents initializing = new InitializingСomponents();
            initializing.init(this);
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

            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            StringCoonection();
        }


        // Класс для добовления компонентов на форму 
        class InitializingСomponents
        {
            // Создание меню
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Редактирование");
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Отчеты");
            public ToolStripMenuItem helpMenu = new ToolStripMenuItem("Справка");

            // Добавление пунктов меню
            public void init(Form1 f1)
            {
                fileMenu.DropDownItems.Add("Создать");
                fileMenu.DropDownItems.Add("Открыть");
                fileMenu.DropDownItems.Add("Сохранить");
                fileMenu.DropDownItems.Add("Выход");

                editMenu.DropDownItems.Add("Добавить");
                editMenu.DropDownItems.Add("Удалить");
                editMenu.DropDownItems.Add("Изменить");

                reportsMenu.DropDownItems.Add("Таблица медального зачета");
                reportsMenu.DropDownItems.Add("Медалисты");
                reportsMenu.DropDownItems.Add("Статистика");
                 
                menuStrip.Items.Add(fileMenu);
                menuStrip.Items.Add(editMenu);
                menuStrip.Items.Add(reportsMenu);
                menuStrip.Items.Add(helpMenu);
                f1.Controls.Add(menuStrip);

                // Добавляем обработчик события для "О программе"
                ToolStripMenuItem aboutProgramMenuItem = new ToolStripMenuItem("О программе");
                aboutProgramMenuItem.Click += new EventHandler(AboutProgram_Click);
                helpMenu.DropDownItems.Add(aboutProgramMenuItem);


                // Создание панели инструментов
                ToolStrip toolStrip = new ToolStrip();
                ToolStripButton addButton = new ToolStripButton("Добавить");
                ToolStripButton deleteButton = new ToolStripButton("Удалить");
                ToolStripButton editButton = new ToolStripButton("Изменить");
                ToolStripButton saveButton = new ToolStripButton("Сохранить");

                // Добавление кнопок на панель инструментов
                toolStrip.Items.Add(addButton);
                toolStrip.Items.Add(deleteButton);
                toolStrip.Items.Add(editButton);
                toolStrip.Items.Add(saveButton);
                f1.Controls.Add(toolStrip);

                // Создание таблицы для отображения данных
                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                f1.Controls.Add(dataGridView);



            }


            private void AboutProgram_Click(object sender, EventArgs e)
            {
                // Обработка нажатия на элемент меню "О программе"
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }

        }

        


        
    }
}











    


 


    


﻿using System;
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
            StringCoonection();
            InitializeComponent();
            InitializingСomponents initializing = new InitializingСomponents();
            initializing.init(this);


        }
        public string StringConnection = "Server=localhost;Database=jak;Trusted_Connection=True";
        // функция подключения к бд 
        void StringCoonection()
        {
             
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




      
        // Класс для добовления компонентов на форму 
        class InitializingСomponents
        {
            // Создание меню
            MenuStrip menuStrip = new MenuStrip();
            
     
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Отчеты");
            public ToolStripMenuItem helpMenu = new ToolStripMenuItem("Справка");

            // Добавление пунктов меню
            public void init(Form1 f1)
            {
                 
                 

                 
                reportsMenu.DropDownItems.Add("Медалисты");
                
                 
                
                menuStrip.Items.Add(reportsMenu);
                menuStrip.Items.Add(helpMenu);
                f1.Controls.Add(menuStrip);

               

                // Создание панели инструментов
                ToolStrip toolStrip = new ToolStrip();
                ToolStripButton addButton = new ToolStripButton("Добавить");
                ToolStripButton deleteButton = new ToolStripButton("Удалить");
                //ToolStripButton editButton = new ToolStripButton("Изменить");
             

                // Добавление кнопок на панель инструментов
                toolStrip.Items.Add(addButton);
                toolStrip.Items.Add(deleteButton);
               // toolStrip.Items.Add(editButton);
                f1.Controls.Add(toolStrip);

                // Создание таблицы для отображения данных
                DataGridView dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                f1.Controls.Add(dataGridView);






                // Добавляем обработчик события для "О программе"
                ToolStripMenuItem aboutProgramMenuItem = new ToolStripMenuItem("О программе");
                aboutProgramMenuItem.Click += new EventHandler(AboutProgram_Click);
                helpMenu.DropDownItems.Add(aboutProgramMenuItem);

                addButton.Click += new EventHandler(ADD_Click);
                deleteButton.Click += new EventHandler(DELETE_Click);

                reportsMenu.Click += new EventHandler(MEDAL_Click);


            }

            // Обработчики нажатия на меню 

            private void AboutProgram_Click(object sender, EventArgs e)
            {
                // Обработка нажатия на элемент меню "О программе"
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }

            private void ADD_Click(object sender, EventArgs e)
            {
                Form1 form1 = new Form1();
                // Обработка нажатия на элемент меню "О программе"
                Form3 form3 = new Form3(form1);
                form3.Show();
            }

            private void DELETE_Click (object sender,  EventArgs e)
            {
                Form1 form1 = new Form1();
                Form4 form4 = new Form4(form1);
                form4.Show();
            }
            
             private void MEDAL_Click(object sender, EventArgs e)
            {
                Form1 form1 = new Form1();
                Form6 form6 = new Form6(form1);
                form6.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); 
            Form5 form5 = new Form5(form1);
            form5.Show();
        }
    }
}











    


 


    


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olimpiada
{
    public partial class Form3 : Form
    {
        private Dictionary<int, Control[]> textBoxesByOption = new Dictionary<int, Control[]>();
        private ListBox listBox;

        public Form3()
        {
            InitializeComponent();
            InitializeComponents();
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

            RemoveExistingControls(selectedIndex);

            switch (selectedIndex)
            {
                case 0:
                    CreateAthleteTextBoxes();
                    break;
                case 1:
                    CreateOlympiadTextBoxes();
                    break;
                case 2:
                    CreateSportTextBoxes();
                    break;
                case 3:
                    CreateCountryTextBoxes();
                    break;
            }
        }



        private void RemoveExistingControls(int selectedIndex)
        {
            if (textBoxesByOption.TryGetValue(selectedIndex, out var controls))
            {
                foreach (var control in controls)
                {
                    Controls.Remove(control);
                }
                textBoxesByOption.Remove(selectedIndex);
            }
        }

        private void CreateDefaultTextBoxes()
        {
            // Логика для создания стандартных текстовых полей при загрузке формы
        }

        private void CreateAthleteTextBoxes()
        {
            textBoxesByOption.Clear();

            var textBoxes = new Control[]
            
            {
                new TextBox { Name = "txtFIO", Location = new Point(300, 50), Size = new Size(100, 20) },
                new TextBox { Name = "txtDate", Location = new Point(300, 80), Size = new Size(100, 20) },
                new TextBox { Name = "txtCountry", Location = new Point(300, 110), Size = new Size(100, 20) }
            };
            
            foreach (var textBox in textBoxes)
            {
                Controls.Add(textBox);
            }
             
            textBoxesByOption[listBox.SelectedIndex] = textBoxes;
        }

        private void CreateOlympiadTextBoxes()
        {
            textBoxesByOption.Clear();
            var textBoxes = new Control[]
            {
                new TextBox { Name = "Date", Location = new Point(300, 50), Size = new Size(100, 20) },
                new TextBox { Name = "Season", Location = new Point(300, 80), Size = new Size(100, 20) },
                new TextBox { Name = "City", Location = new Point(300, 110), Size = new Size(100, 20) },
                new TextBox { Name = "HostContry", Location = new Point(300, 140), Size = new Size(100, 20) }
            };

            foreach (var textBox in textBoxes)
            {
                Controls.Add(textBox);
            }

            textBoxesByOption[listBox.SelectedIndex] = textBoxes;
        }

        private void CreateSportTextBoxes()
        {
            textBoxesByOption.Clear();
            var textBoxes = new Control[]
            {
                new TextBox { Name = "Name", Location = new Point(300, 50), Size = new Size(100, 20) },
               
            };

            foreach (var textBox in textBoxes)
            {
                Controls.Add(textBox);
            }

            textBoxesByOption[listBox.SelectedIndex] = textBoxes;
        }

        private void CreateCountryTextBoxes()
        {
            textBoxesByOption.Clear();
            var textBoxes = new Control[]
            {
                new TextBox { Name = "Name", Location = new Point(300, 50), Size = new Size(100, 20) },
                new TextBox { Name = "gold", Location = new Point(300, 80), Size = new Size(100, 20) },
                new TextBox { Name = "silver", Location = new Point(300, 110), Size = new Size(100, 20) },
                new TextBox { Name = "bronze", Location = new Point(300, 140), Size = new Size(100, 20) },
                new TextBox { Name = "total medals", Location = new Point(300, 170), Size = new Size(100, 20) }
            };

            foreach (var textBox in textBoxes)
            {
                Controls.Add(textBox);
            }

            textBoxesByOption[listBox.SelectedIndex] = textBoxes;
        }





    }
}
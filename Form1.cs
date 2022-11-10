using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace toDoList
{
    public partial class Form1 : Form
    {
        List<AgendaItem> todoList = new List<AgendaItem>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string txtBox = textBox1.Text;
            AgendaItem text = new AgendaItem(txtBox);
            todoList.Add(text);
            Display();
        }

        public void Display()
        {
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = todoList;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            var i = checkedListBox1.SelectedIndex;
            todoList.RemoveAt(i);
            Display();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todoList.Clear();
            Display();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string fileName = saveFileDialog1.FileName;
            System.IO.StreamWriter outfile = new System.IO.StreamWriter(fileName);

            foreach (AgendaItem item in todoList)
            {
                outfile.WriteLine(item);
            }
            outfile.Close();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            var filePath = openFileDialog1.FileName;
            var lines = System.IO.File.ReadAllLines(filePath);
       
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');
                string description = parts[0];
                DateTime date = DateTime.Parse(parts[1]); // convert string to DateTime
                string status = parts[2];

                AgendaItem item = new AgendaItem(description, date, status);
                todoList.Add(item);
                Display();

                if (status == "Done")
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBtn_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveBtn_Click(sender, e);
        }

        private void checkedItem(object sender, ItemCheckEventArgs e)
        {
            var index = e.Index;
            todoList[index].Status = "Done";
        }
    }
}

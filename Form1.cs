using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            /*
             * Add: When the Add button is clicked, get what the user typed into the TextBox.
             * Then, create a new AgendaItem( text ) with that text which will call your 2nd
             * constructor and create an AgendaItem object. and Add it to the List. Then call a 
             * display function that you will write below.
             */
            string txtBox = textBox1.Text;
            AgendaItem text = new AgendaItem(txtBox);
            todoList.Add(text);
            Display();
        }

        /*  Write a display function that does the following code with your listbox
         *  (mine is called checkedListBox1) and your list (mine is called todolist) to 
         *  display the list in the listbox:
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = todolist;
            Note that we could simply add directly to the listbox using checkedListBox1.Items.Add 
            but this gives us more practice with Lists. Test your code to make sure you can add items
            to the list and that they are displayed.
        */
        public void Display()
        {
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = todoList;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            /*
             * When the user clicks on an item in the ListBox and clicks on the Remove button, 
             * get the index of the selected item in the ListBox with the following code 
             * and save it in a variable:
                    checkedListBox1.SelectedIndex
             Then, use the List RemoveAt(i) function to remove an item at index i from your list.
            Then, call your Display function to show the changed list. 
            Test your code to make sure you can remove items from the list.
            This much is worth 80% of the assignment
            */
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
            /* Write a loop that goes through your list and gives each item in the list
             * to outfile.WriteLine(item); After the loop, do outfile.Close(); to close the file.
             * Test this by doing some adds and then save. 
             * */
            foreach(AgendaItem item in todoList)
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
            /*
             * Add a for loop with i from 0 to lines.Length. Inside the loop, add the following code 
             * which will split each line using the commas into the 3 parts you need.
                // get ith line
                string line = lines[i];
                // split line by commas into status, description, date
                string[] parts = line.Split(',');
                string description = parts[0];
                DateTime date = DateTime.Parse(parts[1]); // convert string to DateTime
                string status = parts[2];
            */
            for(int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');
                string description = parts[0];
                DateTime date = DateTime.Parse(parts[1]); // convert string to DateTime
                string status = parts[2];

                /*After this, create a new AgendaItem using the 3rd constructor you wrote and
               * passing in the 3 parts (status, description, date) as arguments and Add it to your 
               * todo list.
               * */
                AgendaItem item = new AgendaItem(description, date, status);
                todoList.Add(item);
                Display();
                /*Then, check the status variable to see if it equals the text "done", and if it
                 * does,  do the following command which will check off the ith checkbox on the 
                 * checkedBoxList:                       
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                Test your program by adding some items to the list and choosing File/Save 
                and then File/New List to clear the list box, and then File/Open to open your 
                saved file.
                */
                if(status == "done")
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                }

    
            }
          
     



        }
    }
}

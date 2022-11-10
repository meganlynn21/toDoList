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

    }
}

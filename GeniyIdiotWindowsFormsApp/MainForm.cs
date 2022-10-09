using System;
using System.Windows.Forms;


namespace GeniyIdiotWindowsFormsApp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var questions = QuestionsStorage.GetAll();
        }
    }
}

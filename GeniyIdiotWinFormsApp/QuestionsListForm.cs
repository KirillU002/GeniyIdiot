using GeniyIdiot.Common;

namespace GeniyIdiotWinFormsApp
{
    public partial class QuestionsListForm : Form
    {
        public QuestionsListForm()
        {
            InitializeComponent();
        }

        private void QuestionsListForm_Load(object sender, EventArgs e)
        {
            var questions = QuestionsStorage.GetAll();
            foreach (var question in questions)
            {
                questionsDataGridView.Rows.Add(question.Text, question.Answer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var row = questionsDataGridView.SelectedRows[0];
            var questionText = row.Cells[0].Value;
            if(questionText != null)
            {

            }
        }
    }
}

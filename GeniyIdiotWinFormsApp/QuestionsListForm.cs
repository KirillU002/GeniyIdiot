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
            var rows = questionsDataGridView.SelectedRows;
            if (rows.Count == 0)
            {
                MessageBox.Show("Вы не выбрали строку");
                return;
            }

            var questionText = rows[0].Cells[0].Value.ToString();
            if(questionText != null)
            {
                QuestionsStorage.Remove(questionText);
            }
            Close();
        }

        private void questionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

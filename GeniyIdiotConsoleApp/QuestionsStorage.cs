
public class QuestionsStorage
{
    public static List<Question> GetAll()
    {
        var questions = new List<Question>();

        if (FileProvider.Exists("questions.txt"))
        {
            var value = FileProvider.GetValue("questions.txt");
            var lines = value.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var values = line.Split('#');
                var text = values[0];
                var answer = Convert.ToInt32(values[1]);

                var question = new Question(text, answer);

                questions.Add(question);
            }
        }

        else
        {
            questions.Add(new Question("Сколько будет 2+2*2?", 6));
            questions.Add(new Question("Бревно нужно распелить на 10 частей. Сколько нужно распилов сделать?", 9));
            questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

            SaveQuestions(questions);
        }
        return questions;         
    }

    public  static void SaveQuestions(List<Question> questions)
    {
        foreach (var question in questions)
        {
            Add(question);
        }
    }

    public static void Add(Question newQuestion)
    {
        var value = $"{newQuestion.Text}#{newQuestion.Answer}";
        FileProvider.Append("questions.txt", value);
    }

    public static void Remove(Question removeQuestion)
    {
        var question = GetAll();
        for (int i = 0; i < question.Count; i++)
        {
            if(question[i].Text == removeQuestion.Text)
            {
                question.RemoveAt(i);
                break;
            }
        }
        question.Remove(removeQuestion);
        FileProvider.Clear("questions.txt");
        SaveQuestions(question);
    }
}

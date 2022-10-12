using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeniyIdiot.Common
{
    public class QuestionsStorage
{
        private static readonly string Path = "questions.json";
        public static List<Question> GetAll()
    {
        var questions = new List<Question>();

        if (FileProvider.Exists(Path))
        {
            var value = FileProvider.GetValue(Path);
                questions = JsonConvert.DeserializeObject<List<Question>>(value);
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
        var jsonData = JsonConvert.SerializeObject(questions);
            FileProvider.Replace(Path, jsonData);
    }

    public static void Add(Question newQuestion)
    {
            var questions = GetAll();
            questions.Add(newQuestion);
            SaveQuestions(questions);
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
        SaveQuestions(question);
    }

        public static void Remove(string questionText)
        {
            var question = GetAll();
            for (int i = 0; i < question.Count; i++)
            {
                if (question[i].Text == questionText)
                {
                    question.RemoveAt(i);
                    break;
                }
            }
            SaveQuestions(question);
        }
    }
}
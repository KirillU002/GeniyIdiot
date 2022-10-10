using System;
using System.Collections.Generic;

namespace GeniyIdiot.Common
{
    public class Game
    {
        List<Question> questions;
        Question currentQuestion;
        int countQuestions;
        User user;
        int questionNumber;

        public Game(User user)
        {
            this.user = user;
            questions = QuestionsStorage.GetAll();
            countQuestions = questions.Count;
            questionNumber = 0;
        }

        public Question GetNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];

            questionNumber++;

            return currentQuestion;
        }

        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }

            questions.Remove(currentQuestion);
        }

        public string GetQuestionNumberText()
        {
            return "Вопроc № " + questionNumber;
        }

        public bool End()
        {
            return questions.Count == 0;
        }

        public string CalculateDiagnose()
        {
            var diagnose = DiagnoseCalculator.Calculate(countQuestions, user.CountRightAnswers);
            user.Diagnose = diagnose;
            UserResultStorage.Save(user);

            return user.Name + ", Ваш диагноз: " + user.Diagnose;
        }
    }
}

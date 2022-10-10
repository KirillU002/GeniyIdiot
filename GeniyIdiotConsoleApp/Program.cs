using GeniyIdiot.Common;

class Programm
{
    static void Main (string [] args)
    {
        while (true)
        {
            Console.WriteLine("Здравствуйте! Как Вас зовут?");
            var user = new User (CheckUserName(Console.ReadLine()));
            var game = new Game (user);

            while (!game.End())
            {
                var currentQuestion = game.GetNextQuestion();

                Console.WriteLine(game.GetQuestionNumberText());
                Console.WriteLine(currentQuestion.Text);

                var userAnswer = GetNumber();

                game.AcceptAnswer(userAnswer);
            }
            var message = game.CalculateDiagnose();

                Console.WriteLine(message);

                var userChoice = GetUserShoice("Хотите посмотреть предыдущие результаты игры?");
                if (userChoice)
                {
                    ShowUserResults();
                }

                userChoice = GetUserShoice("Хотите добавить новый вопрос?");
                if (userChoice)
                {
                    AddNewQuestion();
                }

                userChoice = GetUserShoice("Хотите удалить существующий вопрос?");
                if (userChoice)
                {
                    RemoveQuestion();
                }

                userChoice = GetUserShoice("Хотите начать сначала?");
                if (userChoice == false)
                {
                    break;
                }
        }
    }
   
    static void RemoveQuestion()
    {
        Console.WriteLine("Введите номер удаляемого вопроса: ");
        var questions = QuestionsStorage.GetAll();

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + questions[i].Text);
        }

        var removeQuestionNumber = GetNumber();
        while (removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
        {
            Console.WriteLine("Введите число от 1 до " + questions.Count);
            removeQuestionNumber = GetNumber();
        }

        var removeQuestion = questions[removeQuestionNumber - 1];
        QuestionsStorage.Remove(removeQuestion);
    }
    static int GetNumber()
    {
        int number;
        while (!InputValidator.TryParseToNumber(Console.ReadLine(), out number, out string errorMessage))
        {
            Console.WriteLine(errorMessage);
        }
        return number;
    }
    static void AddNewQuestion()
    {
        Console.WriteLine("Введите текст вопроса: ");
        var text = Console.ReadLine();
        Console.WriteLine("Введите ответ вопроса");
        var answer = GetNumber();

        var newQuestion = new Question(text, answer);

        QuestionsStorage.Add(newQuestion);
    }
    static string CheckUserName(string userName)
    {
        while (true)
        {
            var correctUserName = userName.Contains('#');
            if (correctUserName)
            {
                Console.WriteLine("Имя не должно содержать символ '#'!");
                userName = Console.ReadLine();
            }
            else
            {
                return userName;
            }
        }
    }
    static void ShowUserResults()
    {
        var result = UserResultStorage.GetAll();

        Console.WriteLine("{0,-20}{1,20}{2,10}", "Имя", "Кол-во правильных ответов", "Диагноз");
        foreach (var user in result)
        {
            Console.WriteLine("{0,-20}{1,20}{2,15}", user.Name, user.CountRightAnswers, user.Diagnose);
        }
    }
    static bool GetUserShoice(string massege)
    {
        while (true)
        {
            Console.WriteLine(massege + "Введите: Да или Нет");
            var userInput = Console.ReadLine().ToLower();

            if (userInput == "нет")
                return false;
            if (userInput == "да")
                return true;
        }
    }
}
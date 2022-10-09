class Programm
{
    static void Main (string [] args)
    {
        while (true)
        {
            Console.WriteLine("Здравствуйте! Как Вас зовут?");
            var userName = CheckUserName(Console.ReadLine());
            var user = new User (userName);

            var questions = QuestionsStorage.GetAll();
            var countQuestions = questions.Count;

            var random = new Random();

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));
                var randomQuestionIndex = random.Next (0, questions.Count);
                Console.WriteLine(questions[randomQuestionIndex].Text);

                var userAnswer = GetNumber();
                var rightAnswer = questions[randomQuestionIndex].Answer;

                if (userAnswer == rightAnswer)
                    user.AcceptRightAnswer();

                questions.RemoveAt(randomQuestionIndex);                
            }

            Console.WriteLine("Количество правильных ответов: "+ user.CountRightAnswers);
            var diagnose = CalculateDiagnose(countQuestions, user.CountRightAnswers);
            user.Diagnose = diagnose;
            var diagnoses = GetDiagnoses();
            Console.WriteLine(userName+", Ваш диагноз: "+ diagnose);

            UserResultStorage.Save(user);

            var userChoice = GetUserShoice("Хотите посмотреть предыдущие результаты игры?");
            if (userChoice)
                ShowUserResults();

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
                break;
        }
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

    static void RemoveQuestion()
    {
        Console.WriteLine("Введите номер удаляемого вопроса: ");
        var questions = QuestionsStorage.GetAll();

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine((i+1)+". "+ questions[i].Text);
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

    static void AddNewQuestion()
    {
        Console.WriteLine("Введите текст вопроса: ");
        var text = Console.ReadLine();
        Console.WriteLine("Введите ответ вопроса");
        var answer = GetNumber();

        var newQuestion = new Question(text, answer);

        QuestionsStorage.Add(newQuestion);
    }

    static int GetNumber()
    {
        while (true)
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите число");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введите число от -2*10^9 до 2*10^9");
            }
        }
    }

    static void ShowUserResults()
    {
        var result = UserResultStorage.GetUserResults();

        Console.WriteLine("{0,-20}{1,20}{2,10}", "Имя", "Кол-во правильных ответов", "Диагноз");
        foreach (var user in result)
        {
            Console.WriteLine("{0,-20}{1,20}{2,15}", user.Name, user.CountRightAnswers, user.Diagnose);
        }           
    }    

    static string CalculateDiagnose(int countQuestions, int countRightAnswers)
    {
        var diagnoses = GetDiagnoses();

        var prcentRightAnswers = countRightAnswers * 100 / countQuestions;

        return diagnoses[prcentRightAnswers / 20];
    }

    static bool GetUserShoice(string massege)
    {
        while (true)
        {
            Console.WriteLine(massege + "Введите: Да или Нет");
            var userInput = Console.ReadLine().ToLower();

            if(userInput == "нет")
                return false;
            if(userInput == "да")
                return true;
        }
    }

    static string[] GetDiagnoses()
    {
        var diagnoses = new string[6];
        diagnoses[0] = "кретин";
        diagnoses[1] = "идиот";
        diagnoses[2] = "дурак";
        diagnoses[3] = "нормальный";
        diagnoses[4] = "талант";
        diagnoses[5] = "гений";
        return diagnoses;
    }
}
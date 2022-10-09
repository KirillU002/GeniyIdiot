using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniyIdiotConsoleApp
{
    public static class DiagnoseCalculator
    {
        public static string Calculate(int countQuestions, int countRightAnswers)
        {
            var diagnoses = GetDiagnoses();

            var prcentRightAnswers = countRightAnswers * 100 / countQuestions;

            return diagnoses[prcentRightAnswers / 20];
        }

        private static string[] GetDiagnoses()
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
}

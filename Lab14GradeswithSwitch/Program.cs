using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14GradeswithSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            string prompt = "Enter a test score[0 - 100], -1 to quit: ";
            int score = 0;

            do
            {
                score = validateScore(score, prompt);

                if (score == -1)
                {
                    Console.WriteLine("Good bye..");
                    break;
                }

                string grade = getGrade(score);
                Console.WriteLine($"The grade is {grade}");
                Console.WriteLine();

            } while (true);
        }

        private static int validateScore(int score, string prompt)
        {
            Console.Write(prompt);
            score = int.Parse(Console.ReadLine());

            while (score < -1 || score > 100)
            {
                Console.Write($"{score} is not a valid score. {prompt}");
                score = int.Parse(Console.ReadLine());
            }

            return score;
        }

        private static string getGrade(int score)
        {
            char suffix = '\0';
            char grade = '\0';
            switch (score % 10)
            {
                case 0: case 1: case 2: 
                    suffix = '-';
                    break;
                case 7: case 8: case 9:
                    suffix = '+';
                    break;
                default:
                    suffix = '\0';
                    break;
            }

            if (score == 100)
            {
                suffix = '\0';
            }

            switch (score / 10)
            {
                case 10: case 9:
                    grade = 'A';
                    break;
                case 8:
                    grade = 'B';
                    break;
                case 7:
                    grade = 'C';
                    break;
                case 6:
                    grade = 'D';
                    break;
                default:
                    suffix = '\0';
                    grade = 'F';
                    break;
            }

            return $"{grade}{suffix}";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberQuiz.Utilities
{
    public static class Statictics
    {
        private static string _filePath = Path.Combine(Environment.CurrentDirectory, "record.txt");

        /// <summary>
        /// Creates a new file with the personal record if it doesn't exist in the assembly
        /// </summary>
        public static void CreateRecordFile()
        {
            if (!File.Exists(_filePath))
            {
                File.AppendAllText(_filePath, $"Najlepszy obecny wynik to 0 prób.");
            }
        }

        /// <summary>
        /// Checks if the new record is better than the previous one. If so, it replaces the record value in the text file.
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="attemptsCount"></param>
        public static void isPersonalRecord(int attemptsCount)
        {
            var file = File.ReadAllText(_filePath);
            var recordAttempts = file.Split(' ')[4];
            var bestRecordAttempts = int.Parse(recordAttempts);

            if (attemptsCount < bestRecordAttempts || bestRecordAttempts == 0)
            {
                File.WriteAllText(_filePath, file.Replace(recordAttempts, attemptsCount.ToString()));
            }
        }

        /// <summary>
        /// Displays the personal record in the console
        /// </summary>
        public static void ReadStats()
        {
            var scoreboard = File.ReadAllLines(_filePath);
            var scoreboardToString = string.Join(Environment.NewLine, scoreboard);

            Console.WriteLine(scoreboardToString);
        }
    }
}

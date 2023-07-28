using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberQuiz.Utilities
{
    public class Game
    {
        private int _number;
        private int _attempts = 1;

        /// <summary>
        /// Starts the new game
        /// </summary>
        public void StartGame()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _number = Number.GetNumber();

            var input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int res))
            {
                Console.WriteLine("Podano nieprawidłową wartość! Spróbuj ponownie");
                input = Console.ReadLine();
            }

            int.TryParse(input, out int answer);

            while (answer <= 0 || answer > 100)
            {
                Console.WriteLine("Podano błędną wartość! Spróbuj ponownie");
                SetNewAnswer(ref answer);
            }

            do
            {
                if (answer > _number)
                {
                    Console.WriteLine("Podana liczba jest większa niż docelowa.");
                    _attempts++;
                    SetNewAnswer(ref answer);
                }
                else if (answer < _number)
                {
                    Console.WriteLine("Podana liczba jest mniejsza niż docelowa.");
                    _attempts++;
                    SetNewAnswer(ref answer);
                }
            } while (answer != _number);

            stopwatch.Stop();
            EndGame(stopwatch.Elapsed);
        }

        /// <summary>
        /// Ends the current game
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void EndGame(TimeSpan elapsedTime)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gratulacje!");
            Console.WriteLine("Zgadłeś wygenerowaną liczbę.");
            Console.WriteLine($"Zajęło ci to tylko: {_attempts} prób oraz {elapsedTime.TotalSeconds}s");

            Statictics.isPersonalRecord(_attempts);
        }

        private bool AnswerValidation(string str)
        {
            if (!int.TryParse(str, out int res))
            {
                return false;
            }

            return true;
        }

        private int SetNewAnswer(ref int answer)
        {
            var x = Console.ReadLine();
            if (AnswerValidation(x)) answer = int.Parse(x);
            return answer;
        }
    }
}

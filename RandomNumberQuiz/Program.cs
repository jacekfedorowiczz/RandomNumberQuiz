using RandomNumberQuiz.Utilities;

namespace RandomNumberQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Statictics.CreateRecordFile();

            Greetings();
            do
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        StartGame();
                        Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować...");
                        Console.Read();
                        Console.Clear();
                        Greetings();
                        break;
                    case "2":
                        Statictics.ReadStats();
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Greetings();
                        Console.WriteLine("Podaj prawidłową wartość");
                        break;
                }


            } while (userInput != "0");

            System.Environment.Exit(0);
        }

        private static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Witaj graczu!");
            Console.WriteLine("Twoje zadanie polega na wybraniu jednej liczby z zakresu od 1 do 100. Powodzenia!");
            Console.Write("Podaj swoją odpowiedź: ");

            var game = new Game();
            game.StartGame();
        }

        private static void Greetings()
        {
            Console.WriteLine("Random Number Quiz");
            Console.WriteLine("\t");
            Console.WriteLine("Aby rozpocząć nową grę wciśnij 1");
            Console.WriteLine("Aby wyświetlić statystyki gier wciśnij 2");
            Console.WriteLine("Aby wyjść z programu wciśnij 0");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
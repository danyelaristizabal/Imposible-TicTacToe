using System;
using TicTacToe.Managers; 
namespace TicTacToe
{
    public class AppManager
    {
        enum GeneralInput { One = 1, Two }

        public void ManageTicTacToeGames()
        {
            Console.WriteLine("To play Imposible-TicTacToe press 1");

            Console.WriteLine("To play Ultimate-TicTacToe press 2");

            ChooseAndPlay(GetCorrectInput());

        }

        public static void ChooseAndPlay(int Input) 
        {
            IPlayer myEngine = new Engine();
            IPlayer myPlayer = new Player(); 

            var MyGame = new Game(myPlayer, myEngine);

            IGameManager gameManager; 

            if (GeneralInput.Two.GetHashCode() == Input)
            {
                 gameManager = new Game9x9Manager(MyGame);
            }
            else 
            { 
                 gameManager = new Game3x3Manager(MyGame); 
            }

                gameManager.RunGame();

                Console.WriteLine("To exit app press 1, to continue playing press 2");

                Input = GetCorrectInput();

                if (GeneralInput.Two.GetHashCode() == Input) ChooseAndPlay(GetCorrectInput());
        }

        static int GetCorrectInput() 
        {
            bool incorrectInput = true;

            string answer = ""; 

            while (incorrectInput)
            {
                answer = Console.ReadLine();

                if (CheckInputParse(answer)) 
                {
                    if (CheckInputInsideTypesOfGames(int.Parse(answer)))
                    {

                        incorrectInput = false;
                    }
                }
            }
            return int.Parse(answer);
        }

        static bool CheckInputInsideTypesOfGames(int input)
        {
            if (input == GeneralInput.One.GetHashCode() || input == GeneralInput.Two.GetHashCode())
            {

                return true; 
            }

            return false; 
        }


        static bool CheckInputParse(string input) 
        {
            try
            {
                var choose = int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Incorrect input, Only numbers 1 or 2");
                Console.WriteLine("Enter your input again");
                return false; 
            }
            return true;
        }


    }
}

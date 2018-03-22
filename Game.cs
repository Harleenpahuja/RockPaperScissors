using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RockPaperScissors
{
    public enum Selection
    {
        Rock,
        Paper,
        Scissors
    }
    public class Game
    {
        public void Play()
        {
            List<Selection> list = new List<Selection>();
            IEnumerable<Selection> result = new List<Selection>();
            ConsoleKeyInfo input;
           
            bool anotherRound;
            int gamesPlayed = 0;
            do
            {
                Computer autoPlayer = new Computer();
                User humanPlayer = new User();

                var computerChoice = autoPlayer.Choice();
                var humanChoice = humanPlayer.Choice();
                
                list.Add(computerChoice);
                list.Add(humanChoice);
                result = list.GroupBy(g=>g).Where(m=>m.Count()>1).OrderByDescending(g => g.Count()).Select(x=>x.Key);

                DetermineWinner(computerChoice, humanChoice);
                gamesPlayed = gamesPlayed + 1;
                Console.WriteLine("Play Again?");
                input = Console.ReadKey(true);
                anotherRound = input.KeyChar == 'y';
                 
            } while (anotherRound);
            
            Console.WriteLine("Total  {0}  games played", gamesPlayed);
            Console.WriteLine("The most used word is  {0}  ", result.First());
            Console.ReadLine();
        }

        public void DetermineWinner(Selection computerChoice, Selection humanChoice)
        {
            int hwins = 0;
            int cwins = 0;


            if (humanChoice == computerChoice)
            {
                hwins++;
                cwins++;
                Console.WriteLine("Draw!");
            }
            else if (humanChoice == Selection.Rock && computerChoice == Selection.Scissors || humanChoice == Selection.Paper && computerChoice == Selection.Rock)
            {
                hwins++;
                Console.WriteLine("You won!");

            }
            else if (humanChoice == Selection.Scissors && computerChoice == Selection.Rock || humanChoice == Selection.Rock && computerChoice == Selection.Paper)
            {
                cwins++;
                Console.WriteLine("Computer won!");
            }
            else if (humanChoice == Selection.Scissors && computerChoice == Selection.Paper)
            {
                hwins++;
                Console.WriteLine("You won!");
            }
            else if (humanChoice == Selection.Paper && computerChoice == Selection.Scissors)
            {
                cwins++;
                Console.WriteLine("Computer won!");
            }
            else
            {
                Console.WriteLine("invalid value");
            }


        }
    }
}

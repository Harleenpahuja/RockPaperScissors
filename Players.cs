using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public abstract  class Players
    {
        public abstract Selection Choice();
    }

    public class Computer:Players
    {
        public override Selection Choice()
        {
            Random r = new Random();
           
            Selection selectedElement;
            selectedElement = (Selection)r.Next(1, Enum.GetNames(typeof(Selection)).Length);
            return selectedElement;

        }
    }

    public class User:Players
    {
        public override Selection Choice()
        {
            Selection selectedElement;
            Console.WriteLine("Enter your Choice");
            string myChoice= Console.ReadLine().Trim();
            bool validEntry = Enum.TryParse(myChoice, out selectedElement);

            return selectedElement;

        }

    }
}

using System;

namespace Dojodachi.Models
{
    public class Pet
    {
        public string Name;
        public int Fullness;
        public int Happiness;
        public int Meals;
        public int Energy;
        public Pet(string name)
        {
            Name = name;
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
        }
    }
}
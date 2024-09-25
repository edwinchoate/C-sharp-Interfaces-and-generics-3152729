using System;

namespace IntfChallenge
{
    public class Randomizer : IRandomizable 
    {
        private readonly Random _random = new Random();
        
        public int GetRandomNum (int upperBound) 
        {
            return _random.Next(0, upperBound);
        }

    }
}
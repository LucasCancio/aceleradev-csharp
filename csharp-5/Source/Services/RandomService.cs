using System;

namespace Codenation.Challenge.Services
{
    public class RandomService : IRandomService
    {
        public int RandomInteger(int max)
        {
            return new Random().Next(max);
        }
    }
}
using System;

namespace Codenation.Challenge
{
    public class State
    {
        public State(string name, string acronym, double totalArea)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.totalArea = totalArea;
        }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public double totalArea { get; set; }


    }

}

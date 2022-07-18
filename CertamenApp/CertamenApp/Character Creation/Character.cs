using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp
{
    public class Character 
    {
        public readonly int Arete;
        public int Resevoir { get; set; }
        public int Successess { get; set; } = 0;
        public int Shield { get; set; } = 0;
        public string Name { get; set; }
        public List<ISphere> Spheres = new List<ISphere>();
         

        public Character()
        {
            int arete = 0;
            Name = "Mage";
            Random value = new Random();
            for (int i = 0; i < 1; i++)
            {
                arete = value.Next(2, 6);
                               
            }
            Arete = arete;
            Resevoir = arete;

            Correspondence correspondence = new Correspondence();
            if (correspondence.Level > 0 && correspondence.Level <= Arete)
            {
                Spheres.Add(correspondence);
            }
            Entropy entropy = new Entropy();
            if (entropy.Level > 0 && entropy.Level <= Arete)
            {
                Spheres.Add(entropy);
            }
            Forces forces = new Forces();
            if (forces.Level > 0 && forces.Level <= Arete)
            {
                Spheres.Add(forces);
            }
            Life life = new Life();
            if (life.Level > 0 && life.Level <= Arete)
            {
                Spheres.Add(life);
            }
            Matter matter = new Matter();
            if (matter.Level > 0 && matter.Level <= Arete)
            {
                Spheres.Add(matter);
            }
            Mind mind = new Mind();
            if (mind.Level > 0 && mind.Level <= Arete)
            {
                Spheres.Add(mind);
            }
            Prime prime = new Prime();
            if (prime.Level > 0 && prime.Level <= Arete)
            {
                Spheres.Add(prime);
            }
            Spirit spirit = new Spirit();
            if (spirit.Level > 0 && spirit.Level <= Arete)
            {
                Spheres.Add(spirit);
            }
            Time time = new Time();
            if (time.Level > 0 && time.Level <= Arete)
            {
                Spheres.Add(time);
            }
        }

        public void PlayerCleanUp()
        {
            Successess = 0;
        }


        

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp.Character_Creation
{
    public class EnemyHigh
    {
        public readonly int Arete;
        public int Resevoir { get; set; }
        public int Successess { get; set; } = 0;
        public int Shield { get; set; } = 0;
        public string Name { get; }
        public List<ISphere> Spheres = new List<ISphere>();

        public EnemyHigh()
        {
            Arete = 5;
            Resevoir = Arete;
            Name = "Cult Leader";

            Entropy entropy = new Entropy();
            entropy.Level = 5;
            Spheres.Add(entropy);

            Spirit spirit = new Spirit();
            spirit.Level = 4;
            Spheres.Add(spirit);

            Correspondence correspondence = new Correspondence();
            correspondence.Level = 4;
            Spheres.Add(correspondence);

            Time time = new Time();
            time.Level = 3;
            Spheres.Add(time);
        }
        public void CleanUp()
        {
            Successess = 0;
        }
    }
}

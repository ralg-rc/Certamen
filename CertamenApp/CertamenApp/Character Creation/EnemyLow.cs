using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp.Character_Creation
{
    public class EnemyLow
    {
        public readonly int Arete;
        public int Resevoir { get; set; }
        public int Successess { get; set; } = 0;
        public int Shield { get; set; } = 0;
        public string Name { get; }
        public List<ISphere> Spheres = new List<ISphere>();

        public EnemyLow()
        {
            int arete = 2;
            Arete = arete;
            Resevoir = arete;           
            Name = "Weak Cultist";

            Entropy entropy = new Entropy();
            entropy.Level = 2;
            Spheres.Add(entropy);

            Forces forces = new Forces();
            forces.Level = 2;
            Spheres.Add(forces);


        }

        public void CleanUp()
        {
            Successess = 0;
        }

        
    }
}

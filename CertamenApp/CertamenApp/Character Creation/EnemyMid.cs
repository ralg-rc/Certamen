using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp.Character_Creation
{
    public class EnemyMid
    {
        public readonly int Arete;
        public int Resevoir { get; set; }
        public int Successess { get; set; } = 0;
        public int Shield { get; set; } = 0;
        public string Name { get; }
        public List<ISphere> Spheres = new List<ISphere>();

        public EnemyMid()
        {
            Arete = 4;
            Resevoir = Arete;
            Name = "Cult Ritualist";

            Life life = new Life();
            life.Level = 3;
            Spheres.Add(life);

            Matter matter = new Matter();
            matter.Level = 2;
            Spheres.Add(matter);

            Prime prime = new Prime();
            prime.Level = 4;
            Spheres.Add(prime);

        }
        public void CleanUp()
        {
            Successess = 0;
        }
    }
}
